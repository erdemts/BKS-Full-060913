using BKS.DataModel.CustomAttribute;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    [Table("Alarm")]
    public class Alarm : Author, IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(200, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string HaftaGunleri { get; set; }

        public double AlarmSaati { get; set; }
        [Range(1, 255, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public int Sure { get; set; }

        [MaxLength(200, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Messages))]
        public string Aciklama { get; set; }

        #region Not Mapped

        [NotMapped]
        public TimeSpan FormatedAlarmSaati
        {
            get
            {
                return TimeSpan.FromSeconds(AlarmSaati);
            }
            set
            {
                AlarmSaati = value.TotalSeconds;
            }
        }

        [NotMapped]
        public string DayNames
        {
            get
            {
                string dayNames = Extension.GetSelectedDayNames(this.HaftaGunleri);
                return dayNames;
            }
        }


        [NotMapped]
        public string DisplayName
        {
            get
            {
                return string.Format(Messages.Schedule_Day_Hour_Format, this.DayNames, this.FormatedAlarmSaati);
            }
        }

        #endregion

    }
}
