using BKS.DataModel;
using BKS.DevexLocalizer;
using BKS.Helper;
using DevExpress.Utils.Localization;
using DevExpress.XtraBars.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            this.Load += WelcomeScreen_Load;
        }

        void WelcomeScreen_Load(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = false;
            this.txtPassword.Enabled = false;
            this.btnOk.Enabled = false;
            this.btnCancel.Enabled = false;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

            Thread th = new Thread(new ParameterizedThreadStart(AsyncLoad));
            th.Priority = ThreadPriority.BelowNormal;
            th.Start();
            
        }

        void AsyncLoad(object state)
        {
            this.lblStatus.SafeInvoke(() => this.lblStatus.Text = "Sistem Hazırlanıyor...", true);

            this.SafeInvoke(() =>
            {
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "tr-TR")
                {
                    XtraLocalizer<BarString> baseLoc = BarLocalizer.Active.CreateResXLocalizer();
                    BarLocalizer.Active = new CustomXtraBarLocalizer(baseLoc);
                }

            }, false);


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BKSEntities, BKSDatabaseConfiguration>());
            BKSEntities.DataContext.Kullanici.Load();

            this.lblStatus.SafeInvoke(() => this.lblStatus.Text = "İşlem Tamamlandı.", true);

            this.SafeInvoke(() => { 
                this.txtUserName.Enabled = true;
                this.txtPassword.Enabled = true;
                this.btnOk.Enabled = true;
                this.btnCancel.Enabled = true;

                this.txtUserName.Focus();
            }, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           var kullanici =  BKSEntities.DataContext.Kullanici.FirstOrDefault(u => u.KullaniciAdi == this.txtUserName.Text);



           if (kullanici != null && !string.IsNullOrEmpty(kullanici.Parola) && kullanici.IsGiris)
           {
               string parola = CyrptoTool.DeCryptoText(kullanici.Parola);
               if (object.Equals(this.txtPassword.Text, parola))
               {
                   this.DialogResult = System.Windows.Forms.DialogResult.OK;
                   Program.ApplicationUser = kullanici;
                   return;
               }
           }
           else if (kullanici != null && string.IsNullOrEmpty(kullanici.Parola) && kullanici.IsGiris)
           {
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
               Program.ApplicationUser = kullanici;
               return;
           }

           MessageBox.Show(this, Messages.Validation_User_Text, Messages.Validation_User_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
