﻿using BKS.DataModel.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Kalem")]
    public class Kalem : Author, IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        [UniqueValue(ErrorMessageResourceName = "Validation_UniqueValue", ErrorMessageResourceType = typeof(Messages))]
        public string SeriNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Isim { get; set; }

        public virtual ICollection<OkumaBilgisi> OkumaBilgisi { get; set; }
        public virtual ICollection<OperasyonNokta> OperasyonNokta { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                return string.Format("{0} - {1}", this.SeriNo, this.Isim);
            }
        }
    }
}
