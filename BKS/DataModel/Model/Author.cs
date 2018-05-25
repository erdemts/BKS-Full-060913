using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BKS.DataModel.Model
{
    public abstract class Author
    {
        public DateTime? Olusturma { get; set; }
        public DateTime? Degistirme { get; set; }

        // Navigation properties
        public virtual Kullanici Olusturan { get; set; }
        public virtual Kullanici Degistiren { get; set; }

        // Foreign key
        [ForeignKey("Olusturan")]
        public int? OlusturanID { get; set; }
        [ForeignKey("Degistiren")]
        public int? DegistirenID { get; set; }
    }

}
