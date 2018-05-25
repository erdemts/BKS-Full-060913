using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using System.Data.Entity;
using System;

namespace BKS.Forms.NobetForm
{
    public partial class NobetEdit : Form, BKS.InfraStructure.IEntityForm<Nobet>
    {
        public int ID { get; set; }

        public NobetEdit()
        {
            InitializeComponent();

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.Load += (sender, e) =>
                        {
                            //Personel
                            BKSEntities.DataContext.Personel.Load();
                            this.lkpPersonel.SafeInvoke(() =>
                            this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList()
                            , true);


                            this.LoadData<Nobet>();
                        };

            this.btnOk.Click += (sender, e) =>
                                {
                                    this.SaveEntity<Nobet>();
                                };

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        #region Get/Set Data

        public void GetData(Nobet nobet)
        {
            this.lkpPersonel.EditValue = nobet.Personel;

            if (nobet.NobetTarihi.HasValue)
            {
                this.dtNobetTarihi.EditValue = nobet.Tarih;
                this.tmNobetSaati.EditValue = nobet.NobetSaat;
            }
        }

        public void SetData(Nobet nobet)
        {
            nobet.Personel = this.lkpPersonel.EditValue as Personel;

            if (this.dtNobetTarihi.EditValue != null)
            {
                DateTime date = (DateTime)this.dtNobetTarihi.EditValue;
                TimeSpan time = (this.tmNobetSaati.EditValue is DateTime) ? ((DateTime)this.tmNobetSaati.EditValue).TimeOfDay : (TimeSpan)this.tmNobetSaati.EditValue;
                date = date.Add(time);
                nobet.NobetTarihi = date;
            }
            else
                nobet.NobetTarihi = null;
        }

        #endregion
    }
}
