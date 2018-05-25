using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKS.InfraStructure
{
    public interface IEntityForm<T>
    {
        int ID { get; set; }

        void GetData(T entity);

        void SetData(T entity);
    }
}
