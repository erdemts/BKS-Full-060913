using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.InfraStructure;
using BKS.Helper;
using System.Data.Entity;
using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Forms.ParametreForm;
using System.Threading;
using System.Collections;

namespace BKS.Forms.OperasyonForm
{
    public partial class OperasyonListesi : BaseEntityList
    {
        public OperasyonListesi()
        {
            InitializeComponent();
            this.tabCtrl.SelectedIndexChanged += tabCtrl_SelectedIndexChanged;
        }

        protected override void LoadedAsync()
        {
            if (!object.Equals(base.grdCtrl, this.grdCtrlDevriye))
                base.FindGridControl(this.tabDevriye.Controls);

            this.LoadData(false);
        }


        void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.FindGridControl(this.tabCtrl.SelectedTab.Controls);
            this.LoadData(false);
        }

        private void LoadData(bool isRefresh)
        {
            var items = this.grdCtrl.DataSource as IEnumerable;
            bool isLoadData = (items == null) || (isRefresh) ;
           
            int selectedTabIndex = 0;
            this.tabCtrl.SafeInvoke(()=> selectedTabIndex = this.tabCtrl.SelectedIndex, true);

            if (selectedTabIndex == 0 && isLoadData) // Devriye
            {
                this.LoadData<Operasyon>();
            }
            else if (selectedTabIndex == 1 && isLoadData) // Nokta
            {
                this.LoadData<OperasyonNokta>();
            }
        }

       

        protected override void OpenSelected(object opened)
        {
            int selectedTabIndex = 0;
            this.tabCtrl.SafeInvoke(() => selectedTabIndex = this.tabCtrl.SelectedIndex, true);

            if (selectedTabIndex == 0 ) // Devriye
            {
                this.ShowEdit<OperasyonEdit>(((IEntity)opened).ID);
            }
            else if (selectedTabIndex == 1 ) // Nokta
            {
                OperasyonNokta nokta = (OperasyonNokta)opened;
                if (nokta.Operasyon!=null)
                    this.ShowEdit<OperasyonEdit>(nokta.Operasyon.ID);
            }

            
        }

        public override void NewCommand()
        {
            this.ShowEdit<OperasyonEdit>(null);
        }

        protected override void SilSelected(object[] selected)
        {
            if (selected.Any() && selected[0] is OperasyonNokta)
            {
                this.RemoveListData<OperasyonNokta>(selected);
            }
            else
                this.RemoveListData<Operasyon>(selected);
        }

        #region Operasyon

        public void DevriyePuantaj()
        {
            TarihParam param = new TarihParam();
            DialogResult result = param.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Action<BackroundProcessArg> method = (arg) =>
            {

                int gun_sayisi = (int)(param.BitisTarihi - param.BaslangicTarihi).TotalDays;
                
                if (arg != null)
                    arg.SetMaximum(gun_sayisi);


                DateTime operasyonTarihi = param.BaslangicTarihi;

                while (true)
                {
                    if (operasyonTarihi >= param.BitisTarihi)
                        break;

                    if (arg != null)
                        arg.UpdateProgress();

                    DateTime sonrakiTarihi = operasyonTarihi.AddDays(1);
                    
                    var operasyonQuery = BKSEntities.DataContext.Operasyon.Include(o => o.OperasyonNokta).Where(o => operasyonTarihi <= o.DevriyeTarihi && o.DevriyeTarihi < sonrakiTarihi).OrderBy(o => o.DevriyeTarihi);

                    var operasyonListesi = operasyonQuery.ToList();

                    if (operasyonListesi.Count == 0)
                    {
                        internalDevriyePlanlama(operasyonTarihi, sonrakiTarihi);

                        operasyonListesi = operasyonQuery.ToList();

                        if (operasyonListesi.Count == 0)
                        {
                            operasyonTarihi = sonrakiTarihi;
                            continue;
                        }
                    }

                    internalDevriyePuantaj(operasyonListesi);

                    operasyonTarihi = sonrakiTarihi;
                }

                if (this.grdCtrl != null)
                {
                    this.grdCtrl.SafeInvoke(() =>
                    {
                        this.grdCtrl.RefreshDataSource();
                    }, false);
                }
            };

            BackroundProcess.ShowAction(Messages.Operation_Scoring, method);
        }


        private void internalDevriyePuantaj(IEnumerable<Operasyon> operasyonListesi)
        {

            if (operasyonListesi.Count() == 0)
                return;

            foreach (var operasyon in operasyonListesi)
            {
                if (operasyon.OperasyonNokta == null || !operasyon.OperasyonNokta.Any())
                    continue;

                #region Eski puantaj Iptal
                
                var idList = operasyon.OperasyonNokta.Where(o=>o.OkumaTarihi.HasValue).Select(o => o.ID).ToList();

                if (idList.Any())
                {
                    var eskiOkumaListesi = BKSEntities.DataContext.OkumaBilgisi.Where(okuma => idList.Contains(okuma.OperasyonNokta.ID)).ToList();

                    foreach (var eskiOkuma in eskiOkumaListesi)
                    {
                        eskiOkuma.OperasyonNokta = null;
                    }

                    BKSEntities.DataContext.SaveChanges();
                }
                #endregion

                #region Read Okuma Listesi

                DateTime startdate = operasyon.OperasyonNokta.Min(n => n.NoktaTarihi.Value);
                DateTime enddate = operasyon.OperasyonNokta.Max(n => n.NoktaTarihi.Value);

                TimeSpan devriyesuresi = enddate - startdate;
                startdate = startdate.AddTicks(devriyesuresi.Ticks * (-1));
                enddate = enddate.AddTicks(devriyesuresi.Ticks);

                var tumOkumaListesi = BKSEntities.DataContext.OkumaBilgisi.Where(o => o.OperasyonNokta==null && startdate < o.IslemTarihi && o.IslemTarihi < enddate).ToList();

                #endregion

                foreach (OperasyonNokta planlanlamanokta in operasyon.OperasyonNokta)
                {
                    if (!planlanlamanokta.NoktaTarihi.HasValue)
                        continue;

                    DateTime planlamaNoktaTarihi = planlanlamanokta.NoktaTarihi.Value;
                    int defansSure = planlanlamanokta.DefansSure;

                    #region Okuma Bilgisi

                    var noktaOkumaListesi = tumOkumaListesi.Where(o => o.Nokta.ID == planlanlamanokta.Nokta.ID && o.OperasyonNokta == null);

                    OkumaBilgisi okumabilgisi = null;
                    long oncekifark = long.MaxValue;

                    foreach (var noktaokuma in noktaOkumaListesi)
                    {
                        long fark = (planlamaNoktaTarihi - noktaokuma.IslemTarihi.Value).Ticks;

                        if (fark < 0)
                            fark = fark * (- 1);

                        if (fark < oncekifark)
                        {
                            oncekifark = fark;
                            okumabilgisi = noktaokuma;
                        }
                       
                    }

                    #endregion


                    #region Operasyon Nokta

                    if (planlanlamanokta.OkumaBilgisi == null)
                        planlanlamanokta.OkumaBilgisi = new HashSet<OkumaBilgisi>();

                    if (okumabilgisi != null)
                    {
                        planlanlamanokta.OkumaBilgisi.Add(okumabilgisi);
                        okumabilgisi.OperasyonNokta = planlanlamanokta;

                        planlanlamanokta.Personel = okumabilgisi.Personel;
                        planlanlamanokta.Olay = okumabilgisi.Olay;
                        planlanlamanokta.Kalem = okumabilgisi.Kalem;
                        planlanlamanokta.OkumaTarihi = okumabilgisi.IslemTarihi;

                        if (planlanlamanokta.Olay != null)
                            planlanlamanokta.OperasyonStatu = OperasyonStatu.OkumaOlay;
                        else
                        {

                            bool IsValidRead = (planlamaNoktaTarihi.AddMinutes(defansSure * (-1)) < planlanlamanokta.OkumaTarihi && planlanlamanokta.OkumaTarihi < planlamaNoktaTarihi.AddMinutes(planlanlamanokta.DefansSure));
                            planlanlamanokta.OperasyonStatu = (IsValidRead) ? OperasyonStatu.OkumaBasarili : OperasyonStatu.OkumaUyari;
                        }
                    }
                    else
                    {
                        planlanlamanokta.OperasyonStatu = OperasyonStatu.OkumaEksik;
                    }
                    #endregion
                }

                operasyon.OperasyonStatu = operasyon.OperasyonNokta.Max(o => o.OperasyonStatu);
                BKSEntities.DataContext.SaveChanges();

            }

        }

        public void DevriyePlanlama()
        {
            TarihParam param = new TarihParam();
            DialogResult result = param.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Action<BackroundProcessArg> method = (arg) =>
            {
                internalDevriyePlanlama(param.BaslangicTarihi, param.BitisTarihi, arg);

                if (this.grdCtrl != null)
                {
                    this.grdCtrl.SafeInvoke(() =>
                    {
                        this.grdCtrl.RefreshDataSource();
                    }, false);
                }
            };

            BackroundProcess.ShowAction(Messages.Operation_Schedule, method);
        }

        private void internalDevriyePlanlama(DateTime BaslangicTarihi, DateTime BitisTarihi, BackroundProcessArg arg = null)
        {
            int gun_sayisi = (int)(BitisTarihi - BaslangicTarihi).TotalDays;

            var devriyeList = BKSEntities.DataContext.Devriye.Include(d => d.DevriyeNokta).Where(p => p.IsPasif == false).ToList();

            if (arg != null)
                arg.SetMaximum(gun_sayisi * devriyeList.Count);

            DateTime operasyonTarihi = BaslangicTarihi;

            while (true)
            {
                if (operasyonTarihi >= BitisTarihi)
                    break;

                #region Gunluk Operasyon Olustur

                foreach (var devriye in devriyeList)
                {
                    if (arg!=null)
                        arg.UpdateProgress();

                    DeleteOldOperationItem(operasyonTarihi, devriye);

                    bool IsValid = IsDailyValidation(operasyonTarihi, devriye);

                    if (!IsValid)
                        continue;

                    if (devriye.DevriyeNokta.Count == 0)
                        continue;

                    List<DateTime> baslangicTarihleri = DailyWorkingTimes(operasyonTarihi, devriye);

                    foreach (DateTime baslangicSaat in baslangicTarihleri)
                    {
                        Operasyon operasyon = new Operasyon();
                        operasyon.Devriye = devriye;
                        operasyon.Personel = devriye.Personel;
                        operasyon.DevriyeTarihi = baslangicSaat;

                        operasyon.OperasyonNokta = new HashSet<OperasyonNokta>();

                        foreach (DevriyeNokta devriyenokta in devriye.DevriyeNokta)
                        {
                            OperasyonNokta operasyonnokta = new OperasyonNokta();

                            operasyonnokta.Nokta = devriyenokta.Nokta;
                            operasyonnokta.NoktaTarihi = baslangicSaat.Add(TimeSpan.FromMinutes(devriyenokta.Sure));
                            operasyonnokta.DefansSure = devriye.DefansSure;

                            operasyon.OperasyonNokta.Add(operasyonnokta);
                        }

                        BKSEntities.DataContext.Add<Operasyon>(operasyon);

                        #region Save
                        try
                        {
                            int val = BKSEntities.DataContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string msg = ex.GetValidationErrorMessage();
                            MessageBox.Show(this, string.IsNullOrEmpty(msg) ? ex.Message : msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            BKSEntities.DataContext.CancelChanges<Operasyon>();
                        }
                        #endregion

                    }
                }

                #endregion

                operasyonTarihi = operasyonTarihi.AddDays(1);
            }

        }


        private void DeleteOldOperationItem(DateTime operasyonTarihi, Devriye devriye)
        {

            DateTime operasyonbitis = operasyonTarihi.AddDays(1);

            var deletedItems = BKSEntities.DataContext.Operasyon.Where(p => p.Devriye.ID == devriye.ID && operasyonTarihi <= p.DevriyeTarihi && p.DevriyeTarihi < operasyonbitis);

            foreach (var item in deletedItems)
            {
                BKSEntities.DataContext.Remove<Operasyon>(item);
            }

            try
            {
                BKSEntities.DataContext.SaveChanges();
            }
            catch { }

            
        }

        private List<DateTime> DailyWorkingTimes(DateTime operasyonTarihi, Devriye devriye)
        {
            TimeSpan baslangicSaat = devriye.BaslangicTarihi.Value.TimeOfDay;

            List<DateTime> baslangicTarihleri = new List<DateTime>
                                                        {
                                                            operasyonTarihi.AddTicks(baslangicSaat.Ticks)
                                                        };

            if (devriye.DevriyeGunlukCalismaTipi == DevriyeGunlukCalismaTipi.Saatlik)
            {
                while (true)
                {
                    DateTime sonTarih = baslangicTarihleri.Last();
                    DateTime eklenecekTarih = sonTarih.AddHours(devriye.GunlukPeriod);

                    bool IsStop = ((eklenecekTarih.Date - sonTarih.Date).TotalDays == 1);
                    if (IsStop)
                        break;

                    baslangicTarihleri.Add(eklenecekTarih);
                }
            }

            return baslangicTarihleri;
        }

        private bool IsDailyValidation(DateTime OperasyonTarihi, Devriye devriye)
        {
            bool IsValid = false;

            int days = (int)(OperasyonTarihi.Date - devriye.BaslangicTarihi.Value.Date).TotalDays;

            switch (devriye.DevriyeCalismaTipi)
            {
                case DevriyeCalismaTipi.TekSefer:
                    IsValid = (OperasyonTarihi.Date == devriye.BaslangicTarihi.Value.Date);
                    break;

                case DevriyeCalismaTipi.Gunluk:
                    int dailyMod = days % devriye.CalismaPeriod;
                    IsValid = (dailyMod == 0);
                    break;

                case DevriyeCalismaTipi.Haftalik:
                    int weekNumber =(days/7);
                    int weeklyMod = weekNumber % devriye.CalismaPeriod;

                    string[] workingDays = devriye.HaftaGunleri.Split(',');
                    bool isWorkingDay = workingDays.Any(p => p.Trim() == ((int)OperasyonTarihi.Date.DayOfWeek).ToString() );

                    IsValid = (weeklyMod == 0) && isWorkingDay;
                    break;

                default: IsValid = false; break;
            }

            return IsValid;
        }

        #endregion

        


    }
}
