using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    


    [Table("OperasyonNokta")]
    public class OperasyonNokta : IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Operasyon Operasyon { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Nokta Nokta { get; set; }

        public virtual Kalem Kalem { get; set; }

        public virtual Personel Personel { get; set; }

        public virtual Olay Olay { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? NoktaTarihi { get; set; }

        public DateTime? OkumaTarihi { get; set; }

        public int DefansSure { get; set; }

        public int Statu { get; set; }

        [NotMapped]
        public OperasyonStatu OperasyonStatu
        {
            get
            {
                return (OperasyonStatu)Statu;
            }
            set
            {
                this.Statu = (int)value;
            }
        }

        public virtual ICollection<OkumaBilgisi> OkumaBilgisi { get; set; }

        #region Not Mapped

        [NotMapped]
        public string DevriyeIsim
        {
            get
            {
                return (this.Operasyon!=null && this.Operasyon.Devriye != null) ? this.Operasyon.Devriye.Isim : string.Empty;
            }
        }

        [NotMapped]
        public DateTime DevriyeGunu
        {
            get
            {
                return (this.Operasyon != null && this.Operasyon.DevriyeTarihi.HasValue) ? this.Operasyon.DevriyeTarihi.Value.Date : DateTime.MinValue;
            }
        }

        [NotMapped]
        public TimeSpan NoktaSaati
        {
            get
            {
                return this.NoktaTarihi.HasValue ? this.NoktaTarihi.Value.TimeOfDay : new TimeSpan();
            }
        }

        [NotMapped]
        public TimeSpan OkumaSaati
        {
            get
            {
                return this.OkumaTarihi.HasValue ? this.OkumaTarihi.Value.TimeOfDay : new TimeSpan();
            }
        }

        [NotMapped]
        public string OperasyonStatuIsim
        {
            get
            {
                return (this.Operasyon != null) ? this.OperasyonStatu.GetOperasyonStatuText() : string.Empty;
            }
        }

        [NotMapped]
        public string NoktaIsim
        {
            get
            {
                return (this.Nokta != null) ? this.Nokta.Isim : string.Empty;
            }
        }

        [NotMapped]
        public string KalemIsim
        {
            get
            {
                return (this.Kalem != null) ? this.Kalem.Isim : string.Empty;
            }
        }

        [NotMapped]
        public string PersonelIsim
        {
            get
            {
                string txt = (this.Personel != null) ? this.Personel.DisplayName : string.Empty;
                if (string.IsNullOrEmpty(txt) && this.Operasyon!=null && this.Operasyon.Personel!=null )
                    txt = this.Operasyon.Personel.DisplayName;

                return txt;
            }
        }

        [NotMapped]
        public string OlayIsim
        {
            get
            {
                return (this.Olay != null) ? this.Olay.Aciklama : string.Empty;
            }
        }

        #endregion
    }


    
}
