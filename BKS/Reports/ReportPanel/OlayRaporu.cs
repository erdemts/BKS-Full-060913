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
    public partial class OlayRaporu : UserControl, IReportControl
    {
        public OlayRaporu()
        {
            InitializeComponent();

            this.lkpOlayTipi.LookupInit("DisplayName", new LookUpColumnInfo[] {
                        new LookUpColumnInfo("Aciklama", 100, "Açıklama"),
                        new LookUpColumnInfo("OlayKodu", 50, "Kodu")});

            this.Load += TurRaporu_Load;
        }

        void TurRaporu_Load(object sender, EventArgs e)
        {
            BKSEntities.DataContext.Olay.Load();
            this.lkpOlayTipi.Properties.DataSource = BKSEntities.DataContext.Olay.Local.ToBindingList();
        }

        public string GetReportFileName()
        {
            return "OlayRaporu.rdlc";
        }

        public string GetReportTitle()
        {
            return "Olay Raporu";
        }

        public void SetReportDataSource(Microsoft.Reporting.WinForms.LocalReport localreport)
        {
            var resultSet = from item in BKSEntities.DataContext.OkumaBilgisi
                            where item.Olay != null
                            select item;

            Olay olay = this.lkpOlayTipi.EditValue as Olay;
            if (olay != null)
                resultSet = resultSet.Where(item => item.Olay.ID == olay.ID);

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
