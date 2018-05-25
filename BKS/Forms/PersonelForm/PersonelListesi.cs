using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.InfraStructure;
using BKS.Helper;
using System.Data.Entity;
using BKS.DataModel;
using BKS.DataModel.Model;

namespace BKS.Forms.PersonelForm
{
    public partial class PersonelListesi : BaseEntityList
    {
        public PersonelListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData();
        }

        protected override void OpenSelected(object opened)
        {
            Personel personel = (Personel)opened;
            this.ShowEdit<PersonelEdit>(personel.ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<PersonelEdit>(null);
        }

        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Personel>(selected);
        }
       
        #region Entity Process

        private void LoadData()
        {
            Application.UseWaitCursor = true;
            BKSEntities.DataContext.Personel.Load();
            var dataList = BKSEntities.DataContext.Personel.Local.ToBindingList();

            this.grdCtrl.SafeInvoke(() => {  this.grdCtrl.DataSource = dataList; Application.UseWaitCursor = false; }, false);
        }

        

        #endregion

        #region File Command

        public override void DosyaAktar()
        {
            FileHelper<Personel> fileHelper = new FileHelper<Personel>(this.grdCtrl);
            fileHelper.GetTextHeader = (entity) =>
            {
                string columns = String.Join(fileHelper.seperator.ToString(),
                       PropertyName.For(() => entity.Adi, false),
                       PropertyName.For(() => entity.Soyadi, false),
                       PropertyName.For(() => entity.SicilNo, false),
                       PropertyName.For(() => entity.EPosta, false),
                       PropertyName.For(() => entity.EvTelefonu, false),
                       PropertyName.For(() => entity.CepTelefonu, false),
                       PropertyName.For(() => entity.Adres, false),
                       PropertyName.For(() => entity.KontakAdiSoyadi, false),
                       PropertyName.For(() => entity.KontakTelefon, false),
                       PropertyName.For(() => entity.Aciklama, false)
                       );

                return columns;
            };

            fileHelper.GetTextData = (entity) =>
            {
                string data = String.Join(fileHelper.seperator.ToString(),
                                fileHelper.TextEncoding(entity.Adi),
                                fileHelper.TextEncoding(entity.Soyadi),
                                entity.SicilNo,
                                entity.EPosta,
                                entity.EvTelefonu,
                                entity.CepTelefonu,
                                fileHelper.TextEncoding(entity.Adres),
                                fileHelper.TextEncoding(entity.KontakAdiSoyadi),
                                entity.KontakTelefon,
                                fileHelper.TextEncoding(entity.Aciklama)
                           );

                return data;
            };

            fileHelper.ExportFile();

        }

        public override void DosyaAl()
        {
            FileHelper<Personel> fileHelper = new FileHelper<Personel>(this.grdCtrl);
            fileHelper.ParseTextData = (textline) =>
            {
                string[] lineData = textline.Split(fileHelper.seperator);

                if (lineData.Length < 10)
                    return null;

                Personel entity = new Personel();
                entity.Adi= lineData[0];
                entity.Soyadi=lineData[1];
                entity.SicilNo=lineData[2];
                entity.EPosta=lineData[3];
                entity.EvTelefonu=lineData[4];
                entity.CepTelefonu=lineData[5];
                entity.Adres=lineData[6];
                entity.KontakAdiSoyadi=lineData[7];
                entity.KontakTelefon=lineData[8];
                entity.Aciklama = lineData[9];
                
                return entity;
            };

            fileHelper.ImportFile();
        }

        #endregion


       

    }
}
