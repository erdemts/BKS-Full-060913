using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS.Forms.KullaniciForm
{
    public partial class KullaniciEdit : Form, BKS.InfraStructure.IEntityForm<Kullanici>
    {
        public int ID { get; set; }

        public KullaniciEdit()
        {
            InitializeComponent();

            this.Load += (sender, e) =>
                        {
                            this.LoadData<Kullanici>();
                        };

            this.btnOk.Click += (sender, e) =>
                                {

                                    if (!object.Equals(this.txtParola.Text, this.txtParola2.Text))
                                    {
                                        MessageBox.Show(this,Messages.Message_Parola_Msg, Messages.Message_Parola_Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    this.SaveEntity<Kullanici>();
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        #region Get/Set Data

        public void GetData(Kullanici kullanici)
        {
            this.txtKullaniciAdi.Text = kullanici.KullaniciAdi;
            this.txtAdiSoyadi.Text = kullanici.AdiSoyadi;

            if (!string.IsNullOrEmpty(kullanici.Parola))
            {
                this.txtParola.Text = CyrptoTool.DeCryptoText(kullanici.Parola);
                this.txtParola2.Text = this.txtParola.Text;
            }

            chkGiris.Checked = kullanici.IsGiris;


            if (kullanici.KullaniciAdi == Kullanici.AdminUser)
            {
                this.txtKullaniciAdi.Enabled = false;
                this.chkGiris.Enabled = false;
            }

            if (kullanici.KullaniciAdi == Kullanici.SystemUser)
            {
                this.txtKullaniciAdi.Enabled = false;
                this.txtAdiSoyadi.Enabled = false;
                this.txtParola.Enabled = false;
                this.chkGiris.Enabled = false;
            }

            if (this.ID == 0)
                this.chkGiris.Checked = true;
        }

        public void SetData(Kullanici kullanici)
        {
            kullanici.KullaniciAdi = this.txtKullaniciAdi.Text;
            kullanici.AdiSoyadi = this.txtAdiSoyadi.Text;
            if (!string.IsNullOrEmpty(this.txtParola.Text))
                kullanici.Parola = CyrptoTool.CyrptoText(this.txtParola.Text);
            else
                kullanici.Parola = null;

            kullanici.IsGiris = chkGiris.Checked;
        }

        #endregion
    }
}
