using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.Reports.Core
{
    public interface IReportControl
    {
        string GetReportFileName();
        string GetReportTitle();
        void SetReportDataSource(LocalReport localreport);
    }
}
