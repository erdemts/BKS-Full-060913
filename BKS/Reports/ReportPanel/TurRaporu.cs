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
using System.Collections.ObjectModel;

namespace BKS.Reports.ReportPanel
{
    public partial class TurRaporu : UserControl, IReportControl
    {
        public TurRaporu()
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
            return "TurRaporu.rdlc";
        }

        public string GetReportTitle()
        {
            return "Tur Raporu";
        }

        public void SetReportDataSource(Microsoft.Reporting.WinForms.LocalReport localreport)
        {
            var query = from item in BKSEntities.DataContext.OperasyonNokta
                        select item;

            Devriye devriye = this.lkpDevriye.EditValue as Devriye;
            if (devriye!=null)
                query = query.Where(item => item.Operasyon.Devriye.ID == devriye.ID);

            if (this.dtStart.EditValue != null)
                query = query.Where(item => item.Operasyon.DevriyeTarihi >= ((DateTime)this.dtStart.EditValue).Date);

            if (this.dtEnd.EditValue != null)
                query = query.Where(item => item.Operasyon.DevriyeTarihi <= ((DateTime)this.dtEnd.EditValue).Date);

            ObservableCollection<DsTurRaporu> resultSet = new ObservableCollection<DsTurRaporu>();

            foreach (var oprerasyonnokta in query)
            {
                DsTurRaporu result = new DsTurRaporu();

                result.TurId = oprerasyonnokta.Operasyon.ID;
                result.TurAdi = oprerasyonnokta.DevriyeIsim;
                result.TurTarihi = oprerasyonnokta.DevriyeGunu.ToString("dd.MM.yyyy");
                result.TurSaati = (oprerasyonnokta.Operasyon != null && oprerasyonnokta.Operasyon.DevriyeTarihi.HasValue) ? oprerasyonnokta.Operasyon.DevriyeTarihi.Value.TimeOfDay.ToString() : new TimeSpan().ToString();
                result.Tolerans = oprerasyonnokta.DefansSure.ToString();
                result.Durumu = oprerasyonnokta.Operasyon.OperasyonStatuIsim;

                result.OperasyonNoktaId = oprerasyonnokta.ID;
                result.Nokta = oprerasyonnokta.NoktaIsim;
                result.NoktaSaati = oprerasyonnokta.NoktaSaati.ToString();
                result.OkumaSaati = oprerasyonnokta.OkumaSaati.ToString();
                result.Personel = oprerasyonnokta.PersonelIsim;
                result.Cihaz = oprerasyonnokta.KalemIsim;
                result.Statu = oprerasyonnokta.OperasyonStatuIsim;

                result.Olay = oprerasyonnokta.OlayIsim;

                resultSet.Add(result);
            }

            ReportDataSource rdc = new ReportDataSource(localreport.GetDataSourceNames()[0],resultSet);
            localreport.DataSources.Add(rdc);
        }


        
    }
}
