using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.Reports.DataModel
{
    public class DsTurRaporu
    {
        public int TurId { get; set; }
        public string TurAdi { get; set; }
        public string TurTarihi { get; set; }
        public string TurSaati { get; set; }
        public string Tolerans { get; set; }
        public string Durumu { get; set; }

        public int OperasyonNoktaId { get; set; }
        public string Nokta {get;set;}
        public string NoktaSaati {get;set;}
        public string OkumaSaati {get;set;}
        public string Personel {get;set;}
        public string Cihaz {get;set;}
        public string Statu { get; set; }

        public string Olay { get; set; }
    }
}
