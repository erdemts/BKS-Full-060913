using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace BKS.Forms.DevriyeForm
{
    public partial class DevriyeEdit : Form, BKS.InfraStructure.IEntityForm<Devriye>
    {
        public int ID { get; set; }
        private Devriye entity { get; set; }
//        private ObservableCollection<Nokta> AllItems { get; set; }
//        private ObservableCollection<DevriyeNokta> SelectedItems { get; set; }
//        private ObservableCollection<DevriyeNokta> DeletedItems { get; set; }


        public DevriyeEdit()
        {
            InitializeComponent();

            //this.DeletedItems = new ObservableCollection<DevriyeNokta>();

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.rdCalismaPlani.EditValueChanged += rdCalismaPlani_EditValueChanged;
            this.rdHerSaat.CheckedChanged+=(sender,e)=>
                                            {
                                                this.nmSaat.Enabled = this.rdHerSaat.Checked;
                                            };

            this.btnRight.Click += btnRight_Click;
            this.btnLeft.Click += btnLeft_Click;

            this.Load += Loaded;

            this.btnOk.Click += (sender, e) =>
            {
                this.SaveEntity<Devriye>(this.entity);
            };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };

            this.FormClosed += (sender, e) =>
            {
                if (this.DialogResult != DialogResult.OK)
                {
                    BKSEntities.DataContext.CancelChanges<DevriyeNokta>();
                    BKSEntities.DataContext.CancelChanges<Devriye>();
                    
                }
            };
        }

        void rdCalismaPlani_EditValueChanged(object sender, EventArgs e)
        {
            int selectValue = (this.rdCalismaPlani.EditValue!=null) ? (int) this.rdCalismaPlani.EditValue : -1;

            if (selectValue==1)
            {
                pnlWeekly.Enabled = false;
                pnlDaily.Enabled = true;
            }
            else if (selectValue == 2)
            {
                pnlDaily.Enabled = false;
                pnlWeekly.Enabled = true;
            }
            else
            {
                pnlDaily.Enabled = false;
                pnlWeekly.Enabled = false;
            }
        }

        

        void Loaded(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            this.chkHaftaGunleri.SetDayItems();

            Action loadData = () =>
            {

                this.entity = (this.ID > 0) ? BKSEntities.DataContext.Devriye.Include(p => p.DevriyeNokta).FirstOrDefault(p => p.ID == this.ID) : Activator.CreateInstance<Devriye>();
                
                #region Load Nokta

                

                this.grdSelected.SafeInvoke(() => RefreshSelectedItems(), true);

                

                this.grdAll.SafeInvoke(() => RefreshAllItems(), true);

               

                #endregion

                //Personel
                BKSEntities.DataContext.Personel.Load();
                this.lkpPersonel.SafeInvoke(() =>
                this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList()
                , true);

            };


            loadData.BeginInvoke((asyncresult) =>
            {
                this.SafeInvoke(() => this.GetData(entity), false);
                Application.UseWaitCursor = false;
            }, null);

        }

        private object RefreshSelectedItems()
        {
            return this.grdSelected.DataSource = entity.DevriyeNokta.ToObservableCollection();
        }

        private void RefreshAllItems()
        {
            int[] currentitems = this.entity.DevriyeNokta.Select(p => p.Nokta.ID).ToArray();

            var noktaQuery = from item in BKSEntities.DataContext.Nokta
                             where !currentitems.Contains(item.ID)
                             select item;

            var allItems = noktaQuery.ToList().ToObservableCollection();
            this.grdAll.DataSource = allItems;
        }

        #region Get/Set Data

        public void GetData(Devriye devriye)
        {
            this.txtIsim.Text = devriye.Isim;
            this.chkPasif.Checked = devriye.IsPasif;
            if (devriye.BaslangicTarihi.HasValue)
            {
                this.dtBaslangic.EditValue = devriye.BaslangicTarihi.Value.Date;
                this.tmBaslangic.EditValue = devriye.BaslangicTarihi.Value;
            }

            this.lkpPersonel.EditValue = devriye.Personel;

            this.rdCalismaPlani.EditValue = (int)devriye.DevriyeCalismaTipi;
            
            this.rdBirKez.Checked = (devriye.DevriyeGunlukCalismaTipi == DevriyeGunlukCalismaTipi.TekSefer);
            this.rdHerSaat.Checked = (devriye.DevriyeGunlukCalismaTipi == DevriyeGunlukCalismaTipi.Saatlik);


            if (nmSaat.Minimum <= devriye.GunlukPeriod && devriye.GunlukPeriod <= nmSaat.Maximum)
                this.nmSaat.Value = devriye.GunlukPeriod;

            if (nmDefansDk.Minimum <= devriye.DefansSure && devriye.DefansSure <= nmDefansDk.Maximum)
                this.nmDefansDk.Value = devriye.DefansSure;



            if (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.Gunluk && nmGun.Minimum <= devriye.CalismaPeriod && devriye.CalismaPeriod <= nmGun.Maximum)
                this.nmGun.Value = devriye.CalismaPeriod;

            if (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.Haftalik && nmHafta.Minimum <= devriye.CalismaPeriod && devriye.CalismaPeriod <= nmHafta.Maximum)
                this.nmHafta.Value = devriye.CalismaPeriod;


            chkHaftaGunleri.SetEditValue(devriye.HaftaGunleri);
    
        }

        public void SetData(Devriye devriye)
        {
            devriye.Isim = this.txtIsim.Text;
            devriye.IsPasif = this.chkPasif.Checked;

            if (this.dtBaslangic.EditValue!=null)
            {
                DateTime date = (DateTime)this.dtBaslangic.EditValue;
                TimeSpan time = (this.tmBaslangic.EditValue is DateTime) ? ((DateTime)this.tmBaslangic.EditValue).TimeOfDay : (TimeSpan)this.tmBaslangic.EditValue;
                date = date.Add(time);
                devriye.BaslangicTarihi = date;
            }

            devriye.Personel = this.lkpPersonel.EditValue as Personel;
            

            devriye.DevriyeCalismaTipi = (DevriyeCalismaTipi)this.rdCalismaPlani.EditValue;
            
            if (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.TekSefer)
                devriye.CalismaPeriod = 1;
            else if (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.Gunluk)
                devriye.CalismaPeriod = (int)this.nmGun.Value;
            else if (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.Haftalik)
                devriye.CalismaPeriod = (int)this.nmHafta.Value;


            if (this.rdBirKez.Checked)
            {
                devriye.DevriyeGunlukCalismaTipi = DevriyeGunlukCalismaTipi.TekSefer;
                devriye.GunlukPeriod = 1;
            }

            else if (this.rdHerSaat.Checked)
            {
                devriye.DevriyeGunlukCalismaTipi = DevriyeGunlukCalismaTipi.Saatlik;
                devriye.GunlukPeriod = (int)this.nmSaat.Value;
            }
            
            
            
            devriye.HaftaGunleri = (devriye.DevriyeCalismaTipi == DevriyeCalismaTipi.Haftalik) ? (string)chkHaftaGunleri.EditValue : string.Empty;

            devriye.DefansSure = (int)this.nmDefansDk.Value;

            

        }

        #endregion

        

        void btnLeft_Click(object sender, EventArgs e)
        {

            var rows = from item in this.gridViewSelected.GetSelectedRows()
                        orderby item descending
                        select item;

            foreach (int row in rows)
            {
                DevriyeNokta devriyenokta = (DevriyeNokta)this.gridViewSelected.GetRow(row);
                this.entity.DevriyeNokta.Remove(devriyenokta);
                //BKSEntities.DataContext.DevriyeNokta.Remove(devriyenokta);
            }

            RefreshSelectedItems();
            RefreshAllItems();


        }

        void btnRight_Click(object sender, EventArgs e)
        {
            var rows = from item in this.gridViewAll.GetSelectedRows()
                       orderby item descending
                       select item;

            foreach (int row in rows)
            {
                Nokta nokta = (Nokta)this.gridViewAll.GetRow(row);
                this.entity.DevriyeNokta.Add(new DevriyeNokta(){ Nokta = nokta });
            }

            RefreshSelectedItems();
            RefreshAllItems();
        }
        
    }
}
