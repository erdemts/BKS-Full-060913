using BKS.DataModel.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    
    

    [Table("Anahtar")]
    public class Anahtar : Author, IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        [UniqueValue(ErrorMessageResourceName = "Validation_UniqueValue", ErrorMessageResourceType = typeof(Messages))]
        public string SeriNo { get; set; }
        
        [MaxLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Aciklama{ get; set; }

        public int Tipi { get; set; }

        
        public virtual Personel Personel { get; set; }
        
        public virtual Olay Olay { get; set; }

        public virtual ICollection<OkumaBilgisi> OkumaBilgisi { get; set; }

        #region Not Mapped

        [NotMapped]
        public AnahtarTipi AnahtarTipi
        {
            get
            {
                return (AnahtarTipi)Tipi;
            }
            set
            {
                this.Tipi = (int)value;
            }
        }


        [NotMapped]
        public string DisplayName
        {
            get
            {
                return string.Format("{0}", this.SeriNo);
            }
        }

        [NotMapped]
        public string TipiName
        {
            get
            {
                return this.AnahtarTipi.GetAnahtarTipiText();
            }
        }

        [NotMapped]
        public string ReferansAdi
        {
            get
            {
                string referans = string.Empty;

                if (this.AnahtarTipi == AnahtarTipi.Personel && this.Personel != null) //Personel
                {
                    referans = this.Personel.DisplayName;
                }
                else if (this.AnahtarTipi == AnahtarTipi.Olay && this.Olay != null) //Olay
                {
                    referans = this.Olay.DisplayName;
                }

                return referans;
            }
        }

        #endregion

        
    }
}
