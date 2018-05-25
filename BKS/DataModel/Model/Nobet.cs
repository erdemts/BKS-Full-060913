using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Nobet")]
    public class Nobet : IEntity
    {
        [Key]
        public int ID { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Personel Personel { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? NobetTarihi { get; set; }

        #region Not Mapped

        [NotMapped]
        public DateTime Tarih
        {
            get
            {
                return this.NobetTarihi.HasValue ? this.NobetTarihi.Value.Date : DateTime.MinValue;
            }
        }

        [NotMapped]
        public TimeSpan NobetSaat
        {
            get
            {
                return this.NobetTarihi.HasValue ? this.NobetTarihi.Value.TimeOfDay : new TimeSpan();
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

        #endregion

        
    }
}
