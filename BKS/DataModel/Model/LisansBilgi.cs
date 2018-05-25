using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("LisansBilgisi")]
    public class LisansBilgisi : IEntity
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(150, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string FirmaAdi { get; set; }

        [Column(TypeName = "image")]
        public byte[] FirmaLogo { get; set; }

        
    }
}
