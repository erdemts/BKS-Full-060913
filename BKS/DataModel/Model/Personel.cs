using BKS.DataModel.CustomAttribute;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Personel")]
    public class Personel : Author, IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Adi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Soyadi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        [UniqueValue(ErrorMessageResourceName = "Validation_UniqueValue", ErrorMessageResourceType = typeof(Messages))]
        public string SicilNo { get; set; }

        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string EPosta { get; set; }
        
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string EvTelefonu { get; set; }
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string CepTelefonu { get; set; }
        [MaxLength(1000, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Adres { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string KontakAdiSoyadi { get; set; }
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string KontakTelefon { get; set; }

        [Column(TypeName = "image")]
        public byte[] Fotograf { get; set; }

        [MaxLength(1000, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Aciklama { get; set; }

        public virtual Anahtar Anahtar { get; set; }

        public virtual ICollection<Devriye> Devriye { get; set; }
        public virtual ICollection<Operasyon> Operasyon { get; set; }
        public virtual ICollection<OperasyonNokta> OperasyonNokta { get; set; }
        public virtual ICollection<OkumaBilgisi> OkumaBilgisi { get; set; }
        public virtual ICollection<Nobet> Nobet { get; set; }

        #region Not Mapped

        [NotMapped]
        public string AnahtarAdi
        {
            get
            {
                return (this.Anahtar != null) ? this.Anahtar.DisplayName : string.Empty;
            }
        }
        [NotMapped]
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", this.Adi, this.Soyadi);
            }
        }

        #endregion Not Mapped
    }
}
