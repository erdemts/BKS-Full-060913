using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS.Forms.SystemForm
{
    public partial class RegisterForm : Form
    {

        LisansBilgisi lisansbilgi = null;

        public RegisterForm()
        {
            InitializeComponent();

            this.pictureFirmLogo.MouseDoubleClick += picturePersonel_MouseDoubleClick;

            this.Load += (sender, e) =>
                        {
                           lisansbilgi =  BKSEntities.DataContext.LisansBilgisi.FirstOrDefault();
                           if (lisansbilgi != null)
                           {
                               txtFirmaAdi.Text = lisansbilgi.FirmaAdi;
                               this.PictureBuffer = lisansbilgi.FirmaLogo;
                           }
                            
                        };

            this.btnOk.Click += (sender, e) =>
                                {
                                    if (lisansbilgi == null)
                                    {
                                        lisansbilgi = new LisansBilgisi();
                                        BKSEntities.DataContext.LisansBilgisi.Add(lisansbilgi);
                                    }

                                    lisansbilgi.FirmaAdi = this.txtFirmaAdi.Text;
                                    lisansbilgi.FirmaLogo = this.PictureBuffer;

                                    try
                                    {
                                        BKSEntities.DataContext.SaveChanges();
                                    }
                                    catch (DbEntityValidationException dbEx)
                                    {
                                        string msg = dbEx.GetValidationErrorMessage();
                                    }

                                    this.DialogResult = DialogResult.OK;
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = DialogResult.Cancel;
                                };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtFirmaAdi.Text=null;
            this.PictureBuffer = null;

        }

        #region Picture

        byte[] _PictureBuffer;
        private byte[] PictureBuffer
        {
            get
            {
                return _PictureBuffer;
            }
            set
            {

                _PictureBuffer = value;

                if (_PictureBuffer != null)
                {
                    using (MemoryStream membuf = new MemoryStream(_PictureBuffer))
                    {
                        this.pictureFirmLogo.Image = Image.FromStream(membuf);
                        membuf.Close();
                    }
                }
                else
                    this.pictureFirmLogo.Image = null;
            }

        }


        void picturePersonel_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "JPG Files|*.jpg|JPEG Files|*.jpeg|PNG Files|*.png|GIF Files|*.gif";
            fDialog.CheckPathExists = true;
            fDialog.Multiselect = false;

            DialogResult result = fDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                using (Stream reader = fDialog.OpenFile())
                {
                    byte[] buffer = new byte[reader.Length];
                    reader.Read(buffer, 0, buffer.Length);
                    reader.Close();

                    this.PictureBuffer = ImageHelper.ResizeImage(buffer,477, 120);

                }
            }

        }

        #endregion

        

        
    }
}
