using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using BKS.DataModel;
using BKS.Helper;

namespace BKS.Reports.Core
{

    public partial class BaseReportControl : UserControl
    {
        private IReportControl reportpanel { get; set; }

        public BaseReportControl()
        {
            InitializeComponent();
            this.Load += BaseReportControl_Load;
        }

        void BaseReportControl_Load(object sender, EventArgs e)
        {
        }

        public void SetReportControl(IReportControl reportpanel)
        {
            this.reportpanel = reportpanel;

            Control filterPanel = reportpanel as Control;
            if (filterPanel != null)
            {
                panelParam.Controls.Add(filterPanel);
                filterPanel.Dock = DockStyle.Fill;

                this.lblTitle.Text = reportpanel.GetReportTitle();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rptView.Reset();

            rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            string report = reportpanel.GetReportFileName();
            rptView.LocalReport.ReportPath = string.Format("{0}\\Reports\\{1}", Environment.CurrentDirectory, report);
            
            reportpanel.SetReportDataSource(rptView.LocalReport);

            rptView.RefreshReport();

            

            //Action<BackroundProcessArg> method = (arg) =>
            //{
            //    arg.SetMaximum(1);
            //    arg.UpdateProgress();
                //this.btnReport.SafeInvoke(() =>
                //{

                //}, false);
                
            //};


            //BackroundProcess.ShowAction(Messages.Operation_Report, method);
        }
    }
}
