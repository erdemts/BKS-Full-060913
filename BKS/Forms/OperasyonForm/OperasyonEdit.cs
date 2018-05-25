using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace BKS.Forms.OperasyonForm
{
    public partial class OperasyonEdit : Form, BKS.InfraStructure.IEntityForm<Operasyon>
    {

        

        Action refreshOperasyon { get; set; }

        public int ID { get; set; }

        public OperasyonEdit()
        {
            InitializeComponent();

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.lkpDevriye.LookupInit("Isim", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("Isim", 150, "Devriye İsim")});

            this.Load += OperasyonEdit_Load;
                        

            this.btnOk.Click += (sender, e) =>
                                {
                                    this.SaveEntity<Operasyon>();
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        void OperasyonEdit_Load(object sender, System.EventArgs e)
        {

            var statuList = Enum.GetValues(typeof(OperasyonStatu));

            ComboBoxItemCollection coll = this.ddlStatu.Properties.Items;
   
            coll.BeginUpdate();
            foreach (OperasyonStatu item in statuList)
            {
                coll.Add(new OperasyonStatuItem() { Statu = item });
            }
            coll.EndUpdate();

            //Devriye
            BKSEntities.DataContext.Devriye.Load();
            this.lkpDevriye.SafeInvoke(() =>
               this.lkpDevriye.Properties.DataSource = BKSEntities.DataContext.Devriye.Local.ToBindingList()
               , true);

            //Personel
            BKSEntities.DataContext.Personel.Load();
            this.lkpPersonel.SafeInvoke(() =>
            this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList()
            , true);

            this.LoadData<Operasyon>();
        }

        #region Get/Set Data

        public void GetData(Operasyon operasyon)
        {
            this.lkpPersonel.EditValue = operasyon.Personel;
            this.lkpDevriye.EditValue = operasyon.Devriye;
            this.ddlStatu.EditValue = new OperasyonStatuItem() { Statu = operasyon.OperasyonStatu };

            if (operasyon.DevriyeTarihi.HasValue)
            {
                this.dtNobetTarihi.EditValue = operasyon.DevriyeGunu;
                this.tmNobetSaati.EditValue = operasyon.DevriyeSaati;
            }

            refreshOperasyon = () =>
               {
                   this.grdOperasyonNokta.DataSource = operasyon.OperasyonNokta.ToObservableCollection();
               };

            this.grdOperasyonNokta.SafeInvoke(() => refreshOperasyon(), true);
        }

        public void SetData(Operasyon operasyon)
        {
            operasyon.Personel = this.lkpPersonel.EditValue as Personel;
            operasyon.Devriye = this.lkpDevriye.EditValue as Devriye;
            operasyon.OperasyonStatu = ((OperasyonStatuItem)this.ddlStatu.EditValue).Statu;

            if (this.dtNobetTarihi.EditValue != null)
            {
                DateTime date = (DateTime)this.dtNobetTarihi.EditValue;
                TimeSpan time = (this.tmNobetSaati.EditValue is DateTime) ? ((DateTime)this.tmNobetSaati.EditValue).TimeOfDay : (TimeSpan)this.tmNobetSaati.EditValue;
                date = date.Add(time);
                operasyon.DevriyeTarihi = date;
            }
            else
                operasyon.DevriyeTarihi = null;

            operasyon.IsElleDegisim = true;
        }

        #endregion

        public class OperasyonStatuItem
        {
            public OperasyonStatu Statu { get; set; }

            public override string ToString()
            {
                return this.Statu.GetOperasyonStatuText();
            }

            public override int GetHashCode()
            {
                return (int)this.Statu;
            }


        }

       

      
    }
}
