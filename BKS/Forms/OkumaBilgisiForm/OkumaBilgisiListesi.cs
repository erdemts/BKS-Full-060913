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
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace BKS.Forms.OkumaBilgisiForm
{

    public partial class OkumaBilgisiListesi : BaseEntityList
    {
        public OkumaBilgisiListesi()
        {
            InitializeComponent();
            
        }

        protected override void LoadedAsync()
        {
            this.LoadData<OkumaBilgisi>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<OkumaBilgisiEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<OkumaBilgisiEdit>(null);
        }


        protected override void SilSelected(object[] selected)
        {
            List<OkumaBilgisi> silListe = new List<OkumaBilgisi>();

            foreach (var item in selected)
            {
                var okuma = (OkumaBilgisi)item;

                if (!okuma.IsEslesme)
                    silListe.Add(okuma);
            }

            if (silListe.Any())
                this.RemoveListData<OkumaBilgisi>(silListe.ToArray<object>());

        }

        #region Sync. Log

        public void SyncLog()
        {

            var mainmenu = MainMenu.GetInstance();

            var device = mainmenu.HidDevice;


            if (!(mainmenu.IsDeviceAvailable && device.IsDeviceAttached))
            {
                MessageBox.Show(mainmenu, Messages.Sync_Wrn_Message, Messages.Sync_Wrn_Header, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res_question = MessageBox.Show(mainmenu, Messages.Sync_Question_Message, Messages.Sync_Question_Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res_question == DialogResult.No)
                return;

            Action<BackroundProcessArg> method = (arg) =>
            {

                device.Beep();

                string deviceSerial = device.GetSerialNumber();
                Kalem kalem = BKSEntities.DataContext.Kalem.FirstOrDefault(item => item.SeriNo == deviceSerial);

                var deviceLogList = device.Read_Tag_Log();

                if (!deviceLogList.Any())
                    return;


                arg.SetMaximum(deviceLogList.Count);

                Personel personel = null;
                OkumaBilgisi oncekiokumabilgisi = null;

                while (deviceLogList.Any())
                {
                    var deviceLog = deviceLogList[0];
                    deviceLogList.RemoveAt(0);

                    this.CreateTagData(deviceLog, kalem, ref personel, ref oncekiokumabilgisi);

                    arg.UpdateProgress();
                }

                try
                {
                    this.SafeInvoke(() =>
                    {
                        BKSEntities.DataContext.SaveChanges();
                    }, true);
                }
                catch 
                { 
                }
                finally
                {
                    device.Delete_All_Tag_Log();
                }

                if (this.grdCtrl != null)
                {
                    this.grdCtrl.SafeInvoke(() =>
                    {
                        this.grdCtrl.RefreshDataSource();
                    }, false);
                }


                device.Beep();
            };

            BackroundProcess.ShowAction(Messages.Operation_SyncTag, method);
        }

        void CreateTagData(BKSUSBDriver.TagLogItem deviceLog, Kalem kalem, ref Personel personel, ref OkumaBilgisi oncekiokumabilgisi)
        {
            string strTagNumber = deviceLog.TagNumber.ToString();

            Anahtar anahtar = BKSEntities.DataContext.Anahtar.FirstOrDefault(p => p.SeriNo == strTagNumber);
            Nokta nokta = null;

            if (anahtar == null)
            {
                nokta = BKSEntities.DataContext.Nokta.FirstOrDefault(item => item.SeriNo == strTagNumber);

                if (nokta == null)
                    return;
            }

            if (anahtar != null && anahtar.AnahtarTipi == AnahtarTipi.Personel)
            {
                personel = anahtar.Personel;
                return;
            }
            else if (anahtar != null && anahtar.AnahtarTipi == AnahtarTipi.Olay)
            {
                if (oncekiokumabilgisi != null)
                    oncekiokumabilgisi.Olay = anahtar.Olay;

                return;
            }

            if (kalem != null && personel != null && nokta != null)
            {
                OkumaBilgisi okumabilgisi = new OkumaBilgisi();

                okumabilgisi.IslemTarihi = deviceLog.LogDate;
                okumabilgisi.Kalem = kalem;
                okumabilgisi.Nokta = nokta;
                okumabilgisi.Personel = personel;

                oncekiokumabilgisi = okumabilgisi;

                this.SafeInvoke(() =>
                {
                    BKSEntities.DataContext.OkumaBilgisi.Add(okumabilgisi);
                }, true);
            }

        }
        #endregion
        
        #region File Command
      
        public override void DosyaAktar()
        {
            //FileHelper<OkumaBilgisi> fileHelper = new FileHelper<OkumaBilgisi>(this.grdCtrl);
            //fileHelper.GetTextHeader = (entity) =>
            //    {
            //        string columns = String.Join(fileHelper.seperator.ToString(),
            //               PropertyName.For(() => entity.IslemTarihi, false),
            //               PropertyName.For(() => entity.Kalem, false),
            //               PropertyName.For(() => entity.Personel, false),
            //               PropertyName.For(() => entity.Nokta, false),
            //               PropertyName.For(() => entity.Olay, false),
            //               );

            //        return columns;
            //    };
            
            //fileHelper.GetTextData = (entity) =>
            //{
            //    string data = String.Join(fileHelper.seperator.ToString(),
            //               entity.IslemTarihi.Value.ToString(fileHelper.dateFormat),
            //               (entity.Kalem!=null) ? entity.Kalem.SeriNo : string.Empty,
            //               (entity.Personel!=null && entity.Personel.Anahtar!=null) ? entity.Personel.Anahtar.SeriNo : string.Empty,
            //               (entity.Kalem!=null) ? entity.Kalem.SeriNo : string.Empty,
            //               (entity.Nokta!=null) ? entity.Nokta.SeriNo : string.Empty,
            //               (entity.Olay!=null && entity.Olay.Anahtar!=null) ? entity.Olay.SeriNo : string.Empty,
            //               );

            //    return data;
            //};

            //fileHelper.ExportFile();

        }

        public override void DosyaAl()
        {
            //FileHelper<OkumaBilgisi> fileHelper = new FileHelper<OkumaBilgisi>(this.grdCtrl);
            //fileHelper.ParseTextData = (textline)=>
            //    {
            //        string[] lineData = textline.Split(fileHelper.seperator);

            //        if (lineData.Length < 4)
            //            return null;

            //        OkumaBilgisi okumabilgisi = new OkumaBilgisi();

            //        okumabilgisi.IslemTarihi = DateTime.ParseExact(lineData[0], fileHelper.dateFormat, null);
            //        okumabilgisi.KalemSeriNo = lineData[1];
            //        okumabilgisi.AnahtarSeriNo = lineData[2];
            //        okumabilgisi.NoktaSeriNo = lineData[3];

            //        okumabilgisi.SetOkumaBilgisiRef();

            //        return okumabilgisi;
            //    };

            //fileHelper.ImportFile();
        }

        #endregion

    }
}
