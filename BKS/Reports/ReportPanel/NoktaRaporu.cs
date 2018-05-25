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
    public partial class NoktaRaporu : UserControl, IReportControl
    {
        public NoktaRaporu()
        {
            InitializeComponent();

            this.lkpPersonel.LookupInit("DisplayName", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("DisplayName", 150, "Adı Soyadı")});

            this.Load += TurRaporu_Load;
        }

        void TurRaporu_Load(object sender, EventArgs e)
        {
            BKSEntities.DataContext.Personel.Load();
            this.lkpPersonel.Properties.DataSource = BKSEntities.DataContext.Personel.Local.ToBindingList();
        }

        public string GetReportFileName()
        {
            return "NoktaRaporu.rdlc";
        }

        public string GetReportTitle()
        {
            return "Nokta Raporu";
        }

        public void SetReportDataSource(Microsoft.Reporting.WinForms.LocalReport localreport)
        {
            var resultSet = from item in BKSEntities.DataContext.OkumaBilgisi
                            select item;

            Personel personel = this.lkpPersonel.EditValue as Personel;
            if (personel != null)
                resultSet = resultSet.Where(item => item.Personel.ID == personel.ID);

            if (this.dtStart.EditValue != null)
                resultSet = resultSet.Where(item => item.IslemTarihi >= ((DateTime)this.dtStart.EditValue).Date);

            if (this.dtEnd.EditValue != null)
                resultSet = resultSet.Where(item => item.IslemTarihi <= ((DateTime)this.dtEnd.EditValue).Date);


            resultSet = resultSet.OrderBy(item => item.IslemTarihi);

            ReportDataSource rdc = new ReportDataSource(localreport.GetDataSourceNames()[0], resultSet);
            localreport.DataSources.Add(rdc);
        }


        
    }
}
