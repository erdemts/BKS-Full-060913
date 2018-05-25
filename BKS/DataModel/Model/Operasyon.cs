using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BKS.DataModel.Model
{
    [Table("Operasyon")]
    public class Operasyon : Author, IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Devriye Devriye { get; set; }

        public virtual Personel Personel { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? DevriyeTarihi { get; set; }

        public bool IsElleDegisim { get; set; }

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


        public virtual ICollection<OperasyonNokta> OperasyonNokta { get; set; }


        #region Not Mapped

        [NotMapped]
        public string DevriyeIsim
        {
            get
            {
                return (this.Devriye != null) ? this.Devriye.Isim : string.Empty;
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
        public string OperasyonStatuIsim
        {
            get
            {
                return this.OperasyonStatu.GetOperasyonStatuText();
            }
        }

        [NotMapped]
        public DateTime DevriyeGunu
        {
            get
            {
                return this.DevriyeTarihi.HasValue ? this.DevriyeTarihi.Value.Date : DateTime.MinValue;
            }
        }

        [NotMapped]
        public TimeSpan DevriyeSaati
        {
            get
            {
                return this.DevriyeTarihi.HasValue ? this.DevriyeTarihi.Value.TimeOfDay : new TimeSpan();
            }
        }

        #endregion
    }
}
