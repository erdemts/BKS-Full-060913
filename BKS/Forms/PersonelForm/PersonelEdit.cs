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

namespace BKS.Forms.PersonelForm
{
    public partial class PersonelEdit : Form, BKS.InfraStructure.IEntityForm<Personel>
    {
        public int ID { get; set; }

        public PersonelEdit()
        {
            InitializeComponent();
            
            this.picturePersonel.MouseDoubleClick += picturePersonel_MouseDoubleClick;

            this.Load+= (sender, e) =>
            {
              

                this.LoadData<Personel>();
            };

            this.btnOk.Click += (sender, e) =>
            {
                this.SaveEntity<Personel>();
            };

            this.btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            };
        }

        


        #region Get/Set Data

        public void GetData(Personel personel)
        {
            this.txtAdi.Text = personel.Adi;
            this.txtSoyadi.Text = personel.Soyadi;
            this.txtSicilno.Text = personel.SicilNo;
            this.txtEposta.Text = personel.EPosta;
            this.txtEvTel.Text = personel.EvTelefonu;
            this.txtCepTel.Text = personel.CepTelefonu;
            this.txtAdres.Text = personel.Adres;
            this.txtKontakAdiSoyadi.Text = personel.KontakAdiSoyadi;
            this.txtKontakTel.Text = personel.KontakTelefon;
            this.txtAciklama.Text = personel.Aciklama;
            this.txtPersonel.Text = personel.AnahtarAdi;
            this.PictureBuffer = personel.Fotograf;
            
           
        }

        public void SetData(Personel personel)
        {
            personel.Adi = this.txtAdi.Text;
            personel.Soyadi = this.txtSoyadi.Text;
            personel.SicilNo = this.txtSicilno.Text;
            personel.EPosta = this.txtEposta.Text;
            personel.EvTelefonu = this.txtEvTel.Text;
            personel.CepTelefonu = this.txtCepTel.Text;
            personel.Adres = this.txtAdres.Text;
            personel.KontakAdiSoyadi = this.txtKontakAdiSoyadi.Text;
            personel.KontakTelefon = this.txtKontakTel.Text;
            personel.Aciklama = this.txtAciklama.Text;
            personel.Fotograf = this.PictureBuffer;
        }

        #endregion


        #region Picture

        byte[] _PictureBuffer;
        private byte[] PictureBuffer
        {
            get {
                return _PictureBuffer;
            }
            set {

                _PictureBuffer = value;

                if (_PictureBuffer != null)
                {
                    using (MemoryStream membuf = new MemoryStream(_PictureBuffer))
                    {
                        this.picturePersonel.Image = Image.FromStream(membuf);
                        membuf.Close();
                    }
                }
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

                    this.PictureBuffer = ImageHelper.ResizeImage(buffer, 120, 120);

                }
            }

        }

        #endregion
        
    }
}
