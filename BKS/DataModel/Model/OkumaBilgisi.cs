using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("OkumaBilgisi")]
    public class OkumaBilgisi : Author, IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? IslemTarihi { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Kalem Kalem { get; set; }
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Nokta Nokta { get; set; }
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Personel Personel { get; set; }
        
        public virtual Olay Olay { get; set; }
        
        public virtual OperasyonNokta OperasyonNokta { get; set; }

        public bool IsSistem { get; set; }
        public bool IsElleMudehale { get; set; }

        #region Not Mapped

        [NotMapped]
        public bool IsEslesme
        {
            get
            {
                return (this.OperasyonNokta != null);
            }
        }


        [NotMapped]
        public string PersonelIsim
        {
            get
            {
                return (this.Personel != null) ? this.Personel.DisplayName : string.Empty;
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
        public string OlayIsim
        {
            get
            {
                return (this.Olay != null) ? this.Olay.DisplayName : string.Empty;
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
        public DateTime Tarih
        {
            get
            {
                return (this.IslemTarihi.HasValue) ? this.IslemTarihi.Value.Date : DateTime.MinValue;
            }
        }

        [NotMapped]
        public TimeSpan Saat
        {
            get
            {
                return (this.IslemTarihi.HasValue) ? this.IslemTarihi.Value.TimeOfDay : DateTime.MinValue.TimeOfDay;
            }
        }

        #endregion 

    }
}
