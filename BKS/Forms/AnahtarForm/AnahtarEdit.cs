using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using BKS.Properties;
using System.Collections.Generic;
using BKS.InfraStructure;

namespace BKS.Forms.AnahtarForm
{
    public partial class AnahtarEdit : Form, BKS.InfraStructure.IEntityForm<Anahtar>
    {
        public int ID { get; set; }

        public AnahtarEdit()
        {
            InitializeComponent();

            this.Load += Loaded;


            this.lkpOlayTipi.LookupInit("DisplayName", new LookUpColumnInfo[] {
                        new LookUpColumnInfo("Aciklama", 100, "Açıklama"),
                        new LookUpColumnInfo("OlayKodu", 50, "Kodu")});

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.cmbAnahtarTip.SelectedIndexChanged += cmbAnahtarTip_SelectedIndexChanged;

            this.btnOk.Click += (sender, e) =>
                                {
                                    this.SaveEntity<Anahtar>();
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        void Loaded(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            Anahtar entity = null;

            Action loadData = () =>
            {
                entity = (this.ID > 0) ? BKSEntities.DataContext.Anahtar.Find(this.ID) : Activator.CreateInstance<Anahtar>();


                var paramList = new List<ParametreItem>()
                {
                    new ParametreItem(){Name= Messages.AnahtarTipi_Personel, Value= AnahtarTipi.Personel},
                    new ParametreItem(){Name= Messages.AnahtarTipi_Olay, Value= AnahtarTipi.Olay},
                };

                this.cmbAnahtarTip.AddParameters(paramList);


                //Personel
                BKSEntities.DataContext.Personel.Load();
                this.lkpPersonel.SafeInvoke(() =>
                this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList()
                , false);

                // Olay
                BKSEntities.DataContext.Olay.Load();
                this.lkpOlayTipi.SafeInvoke(() =>
                this.lkpOlayTipi.Properties.DataSource = BKSEntities.DataContext.Olay.Local.ToBindingList()
                , false);

            };


            loadData.BeginInvoke((asyncresult) =>
            {
                this.SafeInvoke(() => this.GetData(entity), false);
                Application.UseWaitCursor = false;
            }, null);

        }

        void cmbAnahtarTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbAnahtarTip.SelectedItem == null)
                return;

            ParametreItem parametre = (ParametreItem)this.cmbAnahtarTip.SelectedItem;

            if (object.Equals( parametre.Value, AnahtarTipi.Personel)) //Personel
            {
                this.lkpOlayTipi.EditValue = null;
                this.lkpOlayTipi.Enabled = false;
                this.lkpPersonel.Enabled = true;
            }
            else if (object.Equals(parametre.Value, AnahtarTipi.Olay)) //Olay
            {
                this.lkpPersonel.EditValue = null;
                this.lkpPersonel.Enabled = false;
                this.lkpOlayTipi.Enabled = true;
            }

        }

       

        #region Get/Set Data

        public void GetData(Anahtar anahtar)
        {
            this.lblSeriNo.Text = anahtar.SeriNo;
            this.txtAciklama.Text = anahtar.Aciklama;

            this.cmbAnahtarTip.SelectedItem = new ParametreItem() { Value = anahtar.AnahtarTipi, Name = anahtar.AnahtarTipi.GetAnahtarTipiText() };

            if (this.cmbAnahtarTip.SelectedItem == null)
                this.cmbAnahtarTip.SelectedIndex = 0;

            this.lkpPersonel.EditValue = anahtar.Personel;
            this.lkpOlayTipi.EditValue = anahtar.Olay;
        }

        public void SetData(Anahtar anahtar)
        {
            anahtar.SeriNo = this.lblSeriNo.Text;
            anahtar.Aciklama = this.txtAciklama.Text;

            if (this.cmbAnahtarTip.SelectedItem != null)
            {
                var item = (ParametreItem)this.cmbAnahtarTip.SelectedItem;
                anahtar.AnahtarTipi = (AnahtarTipi)item.Value;
            }

            anahtar.Personel = this.lkpPersonel.EditValue as Personel;
            //if (anahtar.Personel != null)
            //    anahtar.PersonelID = anahtar.Personel.ID;

            anahtar.Olay = this.lkpOlayTipi.EditValue as Olay;
            //if (anahtar.Olay != null)
            //    anahtar.OlayID = anahtar.Olay.ID;
        }

        #endregion

        private void btnReadSerial_Click(object sender, EventArgs e)
        {
            ReadTagHelper.Read(this, this.lblSeriNo);
        }


       
    }
}
