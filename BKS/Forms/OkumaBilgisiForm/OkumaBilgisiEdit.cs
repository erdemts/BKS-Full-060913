using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data.Entity;
using System.Windows.Forms;


namespace BKS.Forms.OkumaBilgisiForm
{
    public partial class OkumaBilgisiEdit : Form, BKS.InfraStructure.IEntityForm<OkumaBilgisi>
    {
        public int ID { get; set; }

        public OkumaBilgisiEdit()
        {
            InitializeComponent();

            this.SafeInvoke(() => Application.UseWaitCursor = true, false);


            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.lkpNokta.LookupInit("Isim", new LookUpColumnInfo[] {
                       new LookUpColumnInfo("Isim", 100, "Nokta İsim"),
                       new LookUpColumnInfo("SeriNo", 50, "Seri No.")});

            this.lkpOlayTipi.LookupInit("DisplayName", new LookUpColumnInfo[] {
                        new LookUpColumnInfo("Aciklama", 100, "Açıklama"),
                        new LookUpColumnInfo("OlayKodu", 50, "Kodu")});

            this.lkpKalem.LookupInit("Isim", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("Isim", 100, "Kalem İsim"),
                      new LookUpColumnInfo("SeriNo", 50, "Seri No.")});

            this.Load += OkumaBilgisiEdit_Load;
                       
            this.btnOk.Click += btnOk_Click;

            this.btnCancel.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                };
        }

        void OkumaBilgisiEdit_Load(object sender, EventArgs e)
        {

            //Personel
            BKSEntities.DataContext.Personel.Load();
            this.lkpPersonel.SafeInvoke(() =>
            this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList()
            , false);

            // Olay
            BKSEntities.DataContext.Olay.Load();
            this.lkpOlayTipi.SafeInvoke(() =>
            this.lkpOlayTipi.Properties.DataSource = BKSEntities.DataContext.Olay.Local.ToBindingList()
            , false);

            // Nokta
            BKSEntities.DataContext.Nokta.Load();
            this.lkpNokta.SafeInvoke(() =>
            this.lkpNokta.Properties.DataSource = BKSEntities.DataContext.Nokta.Local.ToBindingList()
            , false);

            // Kalem
            BKSEntities.DataContext.Kalem.Load();
            this.lkpKalem.SafeInvoke(() =>
            this.lkpKalem.Properties.DataSource = BKSEntities.DataContext.Kalem.Local.ToBindingList()
            , false);

            this.LoadData<OkumaBilgisi>();

            this.SafeInvoke(() => Application.UseWaitCursor = false, false);
        }

        void btnOk_Click(object sender, EventArgs e)
        {
             this.SaveEntity<OkumaBilgisi>();
        }

        #region Get/Set Data

        public void GetData(OkumaBilgisi okuma)
        {
            if (okuma.IslemTarihi.HasValue)
            {
                this.dtIslemTarihi.EditValue = okuma.IslemTarihi.Value.Date;
                this.tmIslemTarihi.EditValue = okuma.IslemTarihi.Value;
            }

            this.lkpPersonel.EditValue = okuma.Personel;
            this.lkpNokta.EditValue = okuma.Nokta;
            this.lkpOlayTipi.EditValue = okuma.Olay;
            this.lkpKalem.EditValue = okuma.Kalem;

            this.chkElleMudehale.Checked = okuma.IsElleMudehale;
        }

        public void SetData(OkumaBilgisi okuma)
        {
            if (this.dtIslemTarihi.EditValue != null)
            {
                DateTime date = (DateTime)this.dtIslemTarihi.EditValue;
                TimeSpan time = (this.tmIslemTarihi.EditValue is DateTime) ? ((DateTime)this.tmIslemTarihi.EditValue).TimeOfDay : (TimeSpan)this.tmIslemTarihi.EditValue;
                date = date.Add(time);
                okuma.IslemTarihi = date;
            }
            else
                okuma.IslemTarihi = null;

            okuma.Personel = this.lkpPersonel.EditValue as Personel;
            okuma.Nokta = this.lkpNokta.EditValue as Nokta;
            okuma.Olay = this.lkpOlayTipi.EditValue as Olay;
            okuma.Kalem = this.lkpKalem.EditValue as Kalem;

            okuma.IsElleMudehale = true;
        }

        #endregion
    }
}
