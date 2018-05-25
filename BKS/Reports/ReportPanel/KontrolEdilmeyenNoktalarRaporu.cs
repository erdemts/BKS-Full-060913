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
    public partial class KontrolEdilmeyenNoktalarRaporu : UserControl, IReportControl
    {
        public KontrolEdilmeyenNoktalarRaporu()
        {
            InitializeComponent();

            this.lkpDevriye.LookupInit("Isim", new LookUpColumnInfo[] {
                      new LookUpColumnInfo("Isim", 150, "Devriye Isim")});

            this.Load += TurRaporu_Load;
        }

        void TurRaporu_Load(object sender, EventArgs e)
        {
            BKSEntities.DataContext.Devriye.Load();
            this.lkpDevriye.Properties.DataSource = BKSEntities.DataContext.Devriye.Local.ToBindingList();
        }

      

        public string GetReportFileName()
        {
            return "KontrolEdilmeyenNoktalarRaporu.rdlc";
        }

        public string GetReportTitle()
        {
            return "Kontrol Edilmeyen Noktalar Raporu";
        }

        public void SetReportDataSource(Microsoft.Reporting.WinForms.LocalReport localreport)
        {
            int pstatus = (int)OperasyonStatu.OkumaEksik;

            var resultSet = from item in BKSEntities.DataContext.OperasyonNokta
                            where item.Statu == pstatus
                            select item;

            Devriye devriye = this.lkpDevriye.EditValue as Devriye;
            if (devriye != null)
                resultSet = resultSet.Where(item => item.Operasyon.Devriye.ID == devriye.ID);

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
