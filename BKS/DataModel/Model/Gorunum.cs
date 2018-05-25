using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Gorunum")]
    public class Gorunum : Author, IEntity
    {
        [Key]
        public int ID { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(50, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string GorunumAdi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(50, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string GorunumTipi { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public byte[] GorunumData { get; set; }

        public override string ToString()
        {
            return this.GorunumAdi;
        }

    }
}
