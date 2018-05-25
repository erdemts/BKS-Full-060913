using BKS.DataModel.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Kullanici")]
    public class Kullanici : IEntity
    {
        public const string SystemUser = "System";
        public const string AdminUser = "Admin";

        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        [UniqueValue(ErrorMessageResourceName = "Validation_UniqueValue", ErrorMessageResourceType = typeof(Messages))]
        public string KullaniciAdi { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string AdiSoyadi { get; set; }

        [MaxLength(500, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Parola { get; set; }
       
        public bool IsGiris { get; set; }
    }
}
