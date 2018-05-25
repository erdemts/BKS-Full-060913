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

namespace BKS.Forms.ParametreForm
{
    public partial class TarihParam : Form
    {

        public DateTime BaslangicTarihi { get; private set; }
        public DateTime BitisTarihi { get; private set; }

        public TarihParam()
        {
            InitializeComponent();

            this.Load += TarihParam_Load;
            this.btnOk.Click += btnOk_Click;
            this.btnCancel.Click += btnCancel_Click;
            
        }

        void TarihParam_Load(object sender, EventArgs e)
        {
            this.dtStart.EditValue = DateTime.Now.Date;
            this.dtEnd.EditValue = DateTime.Now.AddDays(1).Date;
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            this.BaslangicTarihi = (DateTime)this.dtStart.EditValue;
            this.BitisTarihi = (DateTime)this.dtEnd.EditValue;

            if (this.BaslangicTarihi >= this.BitisTarihi)
            {
                MessageBox.Show(this, Messages.TarihParam_UyarıMesaj, Messages.TarihParam_UyarıBaslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        
        
    }
}
