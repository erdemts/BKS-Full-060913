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

namespace BKS.Forms.NoktaForm
{
    public partial class NoktaEdit : Form, BKS.InfraStructure.IEntityForm<Nokta>
    {
        public int ID { get; set; }

        public NoktaEdit()
        {
            InitializeComponent();
            
            //this.Load += LoadForm;
            this.Load += (sender, e) =>
            {
                this.LoadData<Nokta>();
            };

            this.btnOk.Click += (sender, e) =>
            {
                this.SaveEntity<Nokta>();
            };

            this.btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            };
            
        }


        #region Get/Set Data

        public void GetData(Nokta nokta)
        {
            this.lblSeriNo.Text = nokta.SeriNo;
            this.txtAciklama.Text = nokta.Isim;
        }

        public void SetData(Nokta nokta)
        {

            nokta.SeriNo = this.lblSeriNo.Text;
            nokta.Isim = this.txtAciklama.Text;
        }

        #endregion


        //void LoadForm(object sender, EventArgs e)
        //{
        //    Nokta nokta = (this.ID > 0) ? BKSEntities.DataContext.Nokta.Find(this.ID) : new Nokta();

        //    this.GetData(nokta);
        //}


        private void btnReadSerial_Click(object sender, EventArgs e)
        {
            ReadTagHelper.Read(this, this.lblSeriNo);
        }
        
    }
}
