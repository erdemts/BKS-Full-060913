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

namespace BKS.Forms.OlayForm
{
    public partial class OlayEdit : Form
    {
        public int ID { get; set; }

        public OlayEdit()
        {
            InitializeComponent();
            
            this.Load += LoadForm;
            this.btnOk.Click += btnOk_Click;
            this.btnCancel.Click += btnCancel_Click;
            
        }



        public OlayEdit(int ID)
            : this()
        {
            this.ID = ID;
        }


        #region Get/Set Data

        void GetData(Olay nokta)
        {
            this.txtOlayKodu.Text = nokta.OlayKodu;
            this.txtAciklama.Text = nokta.Aciklama;
        }

        void SetData(Olay nokta)
        {
            nokta.OlayKodu = this.txtOlayKodu.Text;
            nokta.Aciklama = this.txtAciklama.Text;
        }

        #endregion


        void LoadForm(object sender, EventArgs e)
        {
            Olay olay = (this.ID > 0) ? BKSEntities.DataContext.Olay.Find(this.ID) : new Olay();

            this.GetData(olay);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            bool IsValid = false;

            Action save = () =>
                {
                    try
                    {
                        Olay olay = (this.ID > 0) ? BKSEntities.DataContext.Olay.Find(this.ID) : new Olay();
                        this.SetData(olay);

                        string message;
                        IsValid = olay.Validate(out message);

                        if (!IsValid)
                            throw new Exception(message);

                        if (olay.ID < 1)
                            this.SafeInvoke(() => BKSEntities.DataContext.Olay.Add(olay), true);

                        int result = BKSEntities.DataContext.SaveChanges();
                        IsValid = (result > 0);
                    }
                    catch (Exception ex)
                    {
                        this.SafeInvoke(() =>
                        MessageBox.Show(this, ex.Message, "Hata !..", MessageBoxButtons.OK, MessageBoxIcon.Error), true);
                    }
                };

            save.BeginInvoke(new AsyncCallback((result) =>
            {

                Application.UseWaitCursor = false;

                if (IsValid)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }

            }), null);
        }
        
    }
}
