using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("DevriyeNokta")]
    public class DevriyeNokta : IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Devriye Devriye { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public virtual Nokta Nokta { get; set; }

        public double Sure { get; set; }
        public int Siralama { get; set; }

        [NotMapped]
        public string DisplayName 
        { 
            get
            {
                return (this.Nokta != null) ? this.Nokta.DisplayName : string.Empty;
            }
        }

        [NotMapped]
        public DateTime SureEdit
        {
            get
            {
                return new DateTime(TimeSpan.FromMinutes(this.Sure).Ticks);
            }
            set
            {
                if (value == null)
                    Sure = 0;
                else
                    Sure = value.TimeOfDay.TotalMinutes;
            }
        }

        
    }
}
