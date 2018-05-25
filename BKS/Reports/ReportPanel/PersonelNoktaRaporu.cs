using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.Reports.Core;
using BKS.Helper;
using DevExpress.XtraEditors.Controls;
using BKS.DataModel;
using System.Data.Entity;
using BKS.Reports.DataModel;
using Microsoft.Reporting.WinForms;
using BKS.DataModel.Model;

namespace BKS.Reports.ReportPanel
{
    public partial class PersonelNoktaRaporu : UserControl, IReportControl
    {
        public PersonelNoktaRaporu()
        {
            InitializeComponent();

            this.lkpDevriye.LookupInit("Isim", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("Isim", 150, "Devriye Isim")});

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.Load += TurRaporu_Load;
        }

        void TurRaporu_Load(object sender, EventArgs e)
        {
            BKSEntities.DataContext.Devriye.Load();
            this.lkpDevriye.Properties.DataSource = BKSEntities.DataContext.Devriye.Local.ToBindingList();

            BKSEntities.DataContext.Personel.Load();
            this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList();
        }

        public string GetReportFileName()
        {
            return "PersonelNoktaRaporu.rdlc";
        }

        public string GetReportTitle()
        {
            return "Personel Nokta Raporu";
        }

        public void SetReportDataSource(Microsoft.Reporting.WinForms.LocalReport localreport)
        {

            var resultSet = from item in BKSEntities.DataContext.OperasyonNokta
                            select item;

            Devriye devriye = this.lkpDevriye.EditValue as Devriye;
            if (devriye != null)
                resultSet = resultSet.Where(item => item.Operasyon.Devriye.ID == devriye.ID);

            Personel personel = this.lkpPersonel.EditValue as Personel;
            if (personel != null)
                resultSet = resultSet.Where(item => item.Personel.ID == personel.ID);

            if (this.dtStart.EditValue != null)
                resultSet = resultSet.Where(item => item.Operasyon.DevriyeTarihi >= ((DateTime)this.dtStart.EditValue).Date);

            if (this.dtEnd.EditValue != null)
                resultSet = resultSet.Where(item => item.Operasyon.DevriyeTarihi <= ((DateTime)this.dtEnd.EditValue).Date);


            resultSet = resultSet.OrderBy(item => item.NoktaTarihi);

            ReportDataSource rdc = new ReportDataSource(localreport.GetDataSourceNames()[0], resultSet);
            localreport.DataSources.Add(rdc);
        }


        
    }
}
