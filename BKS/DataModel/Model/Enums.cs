using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    public enum AnahtarTipi { Tanimsiz = 0, Personel  = 1, Olay = 2 }

    public enum DevriyeCalismaTipi { TekSefer = 0, Gunluk = 1, Haftalik = 2 }

    public enum DevriyeGunlukCalismaTipi { TekSefer = 0, Saatlik = 1 }

    public enum OperasyonStatu { Planlama = 0, OkumaBasarili = 1, OkumaUyari = 2, OkumaEksik = 3, OkumaOlay = 4}
}
