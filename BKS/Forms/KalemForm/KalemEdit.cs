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

namespace BKS.Forms.KalemForm
{
    public partial class KalemEdit : Form, BKS.InfraStructure.IEntityForm<Kalem>
    {
        public int ID { get; set; }

        public KalemEdit()
        {
            InitializeComponent();

            this.Load += (sender, e) =>
                        {
                            this.LoadData<Kalem>();
                        };

            this.btnOk.Click += (sender, e) =>
                                {
                                    this.SaveEntity<Kalem>();

                                    var mainmenu = MainMenu.GetInstance();
                                    mainmenu.SetDeviceLabel();
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        #region Get/Set Data

        public void GetData(Kalem kalem)
        {
            this.lblSeriNo.Text = kalem.SeriNo;
            this.txtAciklama.Text = kalem.Isim;
        }

        public void SetData(Kalem kalem)
        {
            kalem.SeriNo = this.lblSeriNo.Text;
            kalem.Isim = this.txtAciklama.Text;
        }

        #endregion


        private void btnReadSerial_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = MainMenu.GetInstance();

            if (mainmenu != null && mainmenu.HidDevice.IsDeviceAttached)
            {
                this.lblSeriNo.Text = mainmenu.HidDevice.GetSerialNumber();
                mainmenu.HidDevice.Beep();
            }
        }

        
    }
}
