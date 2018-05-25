using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.InfraStructure
{
    public class ParametreItem
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(this.Name)) ? base.ToString() : this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return object.Equals(this.GetHashCode(), obj.GetHashCode());
        }


        public override int GetHashCode()
        {
            return (this.Value == null) ? -1 : this.Value.GetHashCode();
        }
    }
}
