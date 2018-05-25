using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKS.Forms.GorunumForm
{
    public partial class GorunumEdit : Form
    {
        public GorunumEdit()
        {
            InitializeComponent();

            this.Load += GorunumListesi_Load;
        }

        void GorunumListesi_Load(object sender, EventArgs e)
        {
            
        }
       

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
                return;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }



    }
}
