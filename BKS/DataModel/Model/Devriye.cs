using BKS.DataModel.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{

    
    [Table("Devriye")]
    public class Devriye : Author, IEntity
    {
        public Devriye()
        {
            this.DevriyeCalismaTipi = DevriyeCalismaTipi.Gunluk;
            this.DevriyeGunlukCalismaTipi = DevriyeGunlukCalismaTipi.TekSefer;

            this.CalismaPeriod = 1;
            this.GunlukPeriod = 1;

            this.DevriyeNokta = new ObservableCollection<DevriyeNokta>();
        }

        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Isim { get; set; }

        public bool IsPasif { get; set; }

        public virtual Personel Personel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? BaslangicTarihi { get; set; }

        public int DefansSure { get; set; }

        public int CalismaTipi { get; set; }
        
        [NotMapped]
        public DevriyeCalismaTipi DevriyeCalismaTipi
        {
            get
            {
                return (DevriyeCalismaTipi)CalismaTipi;
            }
            set
            {
                this.CalismaTipi = (int)value;
            }
        }
        
        public int CalismaPeriod { get; set; }
        

        public int GunlukCalismaTipi{ get; set; }
        [NotMapped]
        public DevriyeGunlukCalismaTipi DevriyeGunlukCalismaTipi
        {
            get
            {
                return (DevriyeGunlukCalismaTipi)GunlukCalismaTipi;
            }
            set
            {
                this.GunlukCalismaTipi = (int)value;
            }
        }

        public int GunlukPeriod { get; set; }
        
        [MaxLength(150, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string HaftaGunleri { get; set; }


        [NotMapped]
        public string CalismaTipiIsim
        {
            get
            {
                if (DevriyeCalismaTipi == DevriyeCalismaTipi.TekSefer)
                    return Messages.CalismaPlani_TekSefer;
                else if (DevriyeCalismaTipi == DevriyeCalismaTipi.Gunluk)
                    return Messages.CalismaPlani_Gunluk;
                else if (DevriyeCalismaTipi == DevriyeCalismaTipi.Haftalik)
                    return Messages.CalismaPlani_Haftalik;
                else
                    return "";
            }
        }


        public virtual ICollection<DevriyeNokta> DevriyeNokta { get; set; }
        public virtual ICollection<Operasyon> Operasyon { get; set; }
    }
}
