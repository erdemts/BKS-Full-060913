using DevExpress.Utils.Localization;
using DevExpress.XtraBars.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.DevexLocalizer
{
    public class CustomXtraBarLocalizer : BarLocalizer
    {
        private XtraLocalizer<BarString> baseLoc { get; set; }

        public CustomXtraBarLocalizer(XtraLocalizer<BarString> baseLoc)
        {
            this.baseLoc = baseLoc;
        }

        public override string Language
        {
            get
            {
                return "tr-TR";
            }
        }

        public override string GetLocalizedString(BarString id)
        {
            switch (id)
            {
                case BarString.CustomizeToolbarSuperTipText :
                        return "Çabuk Araç Çubuğunu Özelleştir";
            }

            return this.baseLoc.GetLocalizedString(id);
        }
    }
}
