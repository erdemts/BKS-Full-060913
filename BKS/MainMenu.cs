
using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.DevexLocalizer;
using BKS.Helper;
using BKS.InfraStructure;
using BKS.Reports.Core;
using BKSUSBDriver;
using DevExpress.Utils.Localization;
using DevExpress.Utils.Localization.Internal;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKS
{
    public partial class MainMenu : Form
    {
        private Thread loadThread { get; set; }
        private Dictionary<string,Type> listMenuContent {get;set;}
        private BaseEntityList selectedContent { get; set; }
        private IReportControl selectedReportPanel { get; set; }
        
        public HIDConnector HidDevice = null;
        public bool IsDeviceAvailable = false;

        public MainMenu()
        {
            InitializeComponent();

            this.rbCtrl.ItemClick += new ItemClickEventHandler(rbCtrl_ItemClick);

            this.nvMenu.ActiveGroupChanged += nvMenu_ActiveGroupChanged;
           

            foreach (NavBarItem nvItem in this.nvMenu.Items)
            {
                nvItem.LinkClicked += new NavBarLinkEventHandler(this.nvItem_LinkClicked);
            }

            this.Load += (sender, e) =>
                {
                    HideRibonGrupButton();

                    Thread th = new Thread(new ParameterizedThreadStart(MainMenu_Load));
                    th.Priority = ThreadPriority.BelowNormal;
                    th.Start();
                };
        }

        private void MainMenu_Load(object state)
        {
            BKSEntities.DataContext.Kalem.Load();

            LisansBilgisi lisans = BKSEntities.DataContext.LisansBilgisi.FirstOrDefault();

            if (lisans != null && !string.IsNullOrEmpty(lisans.FirmaAdi))
                lblCompanyName.Text = lisans.FirmaAdi;
            else
                lblCompanyName.Text = string.Empty;

            this.SafeInvoke(() =>
            {
                this.lblUserName.Text = Program.ApplicationUser.AdiSoyadi;

                this.HidDevice = new HIDConnector();
                this.HidDevice.UsbChanged += HidDevice_UsbChanged;
                this.HidDevice.Connect();
                if (!this.HidDevice.IsDeviceAttached)
                    this.SetDeviceLabel();
            }
                , true);

            this.pnlContent.SafeInvoke(() => this.SwitchMenu("nvBtnOkuma"), true);
            
        }


        public static MainMenu GetInstance()
        {
            MainMenu mainmenu = null;

            foreach (var form in Application.OpenForms)
            {
                if (form is MainMenu)
                {
                    mainmenu = (MainMenu)form;
                    break;
                }
            }

            return mainmenu;
        }

        #region Detect Connected Device

        void HidDevice_UsbChanged(object sender, EventArgs e)
        {
            this.SetDeviceLabel();
        }

        public void SetDeviceLabel()
        {
            if (this.IsDisposed)
                return;

            this.IsDeviceAvailable = false;

            if (this.HidDevice.IsDeviceAttached)
            {
                this.statusBar.SafeInvoke(() =>
                {
                    string serialnumber = this.HidDevice.GetSerialNumber();

                    BKS.DataModel.Model.Kalem kalem = BKSEntities.DataContext.Kalem.Local.FirstOrDefault(item => item.SeriNo == serialnumber);
                    if (kalem != null)
                    {
                        this.lblDeviceConnection.Image = BKS.Properties.Resources.device_connect;
                        this.lblDeviceConnection.Text = string.Format("Bağlı Cihaz : {0} [ SN:{1} ]", kalem.Isim, kalem.SeriNo);
                        this.IsDeviceAvailable = true;

                        this.HidDevice.Beep();
                        this.HidDevice.SetDateTime(DateTime.Now);
                    }
                    else
                    {
                        this.lblDeviceConnection.Image = BKS.Properties.Resources.device_invalid;
                        this.lblDeviceConnection.Text = string.Format("Bağlı Cihaz : Tanımlanamadı [ SN:{0} ]", serialnumber);
                    }
                }, false);
            }
            else
            {
                this.statusBar.SafeInvoke(() =>
                {
                    this.lblDeviceConnection.Image = BKS.Properties.Resources.device_not_connect;
                    this.lblDeviceConnection.Text = "Cihaz Bağlantısı Yok";
                }, false);
            }
        }

        #endregion

        void rbCtrl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item is BarButtonItem)
            {
                BarButtonItem btn = (BarButtonItem)e.Item;
                this.RunCommand(btn.Name);
            }
        }

        private void nvItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.SwitchMenu(e.Link.ItemName);
        }


        #region Menu operation

        internal void RunCommand(string CommandName)
        {
            if (selectedContent == null)
                return;

            switch (CommandName)
            {
                case "rbBtnAc": selectedContent.OpenCommand(); return;
                case "rbBtnYeni": selectedContent.NewCommand(); return;
                case "rbBtnSil": selectedContent.SilCommand(); return;
                case "rbBtnYazdir": selectedContent.YazdirCommand(); return;
                case "rbBtnBul": selectedContent.GelismisBul(); return;
                case "rbBtnClearFilter": selectedContent.FiltreyiKaldir(); return;
                case "rbBtnHizliBul": selectedContent.HizliBul(); return;
                case "rbBtnFileImport": selectedContent.DosyaAl(); return;
                case "rbBtnFileExport": selectedContent.DosyaAktar(); return;
                case "rbBtnGorunumler": selectedContent.Gorunumler(); return;
                case "rbBtnDevriyePlan":
                    ((BKS.Forms.OperasyonForm.OperasyonListesi)selectedContent).DevriyePlanlama();
                    return;
                case "rbBtnPuantaj":
                    ((BKS.Forms.OperasyonForm.OperasyonListesi)selectedContent).DevriyePuantaj();
                    return;
                case "rbBtnSyncLog":
                    ((BKS.Forms.OkumaBilgisiForm.OkumaBilgisiListesi)selectedContent).SyncLog();
                    return;
                case "rbBtnSyncTag":
                    ((BKS.Forms.AnahtarForm.AnahtarListesi)selectedContent).SyncTag();
                    return;
                case "rbBtnSyncPoint":
                    ((BKS.Forms.NoktaForm.NoktaListesi)selectedContent).SyncPoint();
                    return;
                case "rbBtnSyncAlarm":
                    ((BKS.Forms.AlarmForm.AlarmListesi)selectedContent).SyncAlarm();
                    return;

                case "rbBtnInfo":
                    ShowInfoForm();
                    return;
                case "rbBtnRegister":
                    ShowRegisterForm();
                    return;
                default: return;
            }
        }

        private void ShowInfoForm()
        {
            

            if (this.selectedContent != null && this.selectedContent is BaseEntityList)
            {
                object selectedRecord = ((BaseEntityList)this.selectedContent).GetSelectedRecord();

                if (selectedRecord != null && selectedRecord is Author)
                {
                    Author author = (Author)selectedRecord;

                    BKS.Forms.SystemForm.InfoForm infoform = new Forms.SystemForm.InfoForm();
                    
                    infoform.lblOlusturmaZamani.Text = (author.Olusturma.HasValue) ? author.Olusturma.Value.ToString("dd.MM.yyyy HH:mm:ss") : string.Empty;
                    infoform.lblOlusturan.Text = (author.Olusturan != null) ? author.Olusturan.AdiSoyadi : string.Empty;

                    infoform.lblDegistirmeZamani.Text = (author.Degistirme.HasValue) ? author.Degistirme.Value.ToString("dd.MM.yyyy  HH:mm:ss") : string.Empty;
                    infoform.lblDegistiren.Text = (author.Degistiren != null) ? author.Degistiren.AdiSoyadi : string.Empty;
                    
                    infoform.ShowDialog();
                }
            }

            
        }

        private void ShowRegisterForm()
        {
            BKS.Forms.SystemForm.RegisterForm register = new Forms.SystemForm.RegisterForm();
            DialogResult diag = register.ShowDialog();
            if (diag == System.Windows.Forms.DialogResult.OK)
                lblCompanyName.Text = register.txtFirmaAdi.Text;
        }


       

        internal void SwitchMenu(string MenuName)
        {
            if (loadThread != null && loadThread.IsAlive)
                return;

            #region Clear Content

            foreach (var item in this.pnlContent.Controls)
            {
                UserControl ctrl = item as UserControl;
                if (ctrl != null && !ctrl.IsDisposed)
                    ctrl.Dispose();
            }

            this.selectedReportPanel = null;
            this.selectedContent = null;
            this.pnlContent.Controls.Clear();

            #endregion


            HideRibonGrupButton();

            switch (MenuName)
            {
                case "nvBtnPersonel":
                    this.selectedContent = new BKS.Forms.PersonelForm.PersonelListesi();
                    break;
                case "nvBtnNobet":
                    this.selectedContent = new BKS.Forms.NobetForm.NobetListesi();
                    break;
                case "nvBtnOperasyon":
                    this.rbPgGrpOperasyon.Visible = true;
                    this.selectedContent = new BKS.Forms.OperasyonForm.OperasyonListesi();
                    break;
                case "nvBtnOkuma":
                    this.rbPgGrpDeviceLog.Visible = true;
                    this.selectedContent = new BKS.Forms.OkumaBilgisiForm.OkumaBilgisiListesi();
                    break;
                case "nvBtnDevPlan":
                    this.selectedContent = new BKS.Forms.DevriyeForm.DevriyeListesi();
                    break;
                case "nvBtnKalem":
                    this.selectedContent = new BKS.Forms.KalemForm.KalemListesi();
                    break;
                case "nvBtnAnahtar":
                    this.rbPgGrpDeviceTag.Visible = true;
                    this.selectedContent = new BKS.Forms.AnahtarForm.AnahtarListesi();
                    break;
                case "nvBtnNokta":
                    this.rbPgGrpDevicePoint.Visible = true;
                    this.selectedContent = new BKS.Forms.NoktaForm.NoktaListesi();
                    break;
                case "nvBtnKullanici":
                    this.selectedContent = new BKS.Forms.KullaniciForm.KullaniciListesi();
                    break;
                case "nvBtnOlay":
                    this.selectedContent = new BKS.Forms.OlayForm.OlayListesi();
                    break;
                case "nvBtnAlarm":
                    this.rbPgGrpDeviceAlarm.Visible = true;
                    this.selectedContent = new BKS.Forms.AlarmForm.AlarmListesi();
                    break;

                case "nvBtnTurRaporu":
                    this.selectedReportPanel = new BKS.Reports.ReportPanel.TurRaporu();
                    break;

                case "nvBtnKENoktalarRaporu":
                    this.selectedReportPanel = new BKS.Reports.ReportPanel.KontrolEdilmeyenNoktalarRaporu();
                    break;
                case "nvBtnOlayRaporu":
                    this.selectedReportPanel = new BKS.Reports.ReportPanel.OlayRaporu();
                    break;

                case "nvBtnNoktaRaporu":
                    this.selectedReportPanel = new BKS.Reports.ReportPanel.NoktaRaporu();
                    break;

                case "nvBtnPersonelNoktaRaporu":
                    this.selectedReportPanel = new BKS.Reports.ReportPanel.PersonelNoktaRaporu();
                    break;
            }

            #region Set Panel

            if (this.selectedContent != null)
            {
                this.selectedContent.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(selectedContent);

                loadThread = new Thread(() =>
                {
                    selectedContent.OnLoad();
                }
                );
                loadThread.Priority = ThreadPriority.BelowNormal;
                loadThread.Start();
            }
            else if (this.selectedReportPanel != null)
            {
                var reportControl = new BKS.Reports.Core.BaseReportControl();
                reportControl.Dock = DockStyle.Fill;
                reportControl.SetReportControl(this.selectedReportPanel);

                this.pnlContent.Controls.Add(reportControl);
            }

            #endregion

        }

        void nvMenu_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            switch (e.Group.Name)
            {
                case "nvGrpOperasyon":
                    this.SafeInvoke(() => this.SwitchMenu("nvBtnOkuma"), false);
                    break;
                case "nvGrpTanimlama":
                    this.SafeInvoke(() => this.SwitchMenu("nvBtnPersonel"), false);
                    break;
                case "nvGrpRaporlar":
                    this.SafeInvoke(() => this.SwitchMenu("nvBtnTurRaporu"), false);
                    break;

                default: break;
            }
        }


        void HideRibonGrupButton()
        {
            this.rbPgGrpOperasyon.Visible = false;
            this.rbPgGrpDeviceTag.Visible = false;
            this.rbPgGrpDevicePoint.Visible = false;
            this.rbPgGrpDeviceLog.Visible = false;
            this.rbPgGrpDeviceAlarm.Visible = false;
        }
        

        #endregion


    }


    

    


        
}
