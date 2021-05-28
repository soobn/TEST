using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTEntityFrameworkCore.Entities
{
    public abstract class BaseEntity<T>
    {
        public BaseEntity() { }
        [SqlSugar.SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public T Id { set; get; }
        public override bool Equals(object obj)
        {
            if (obj is BaseEntity<T>) {
                return (obj as BaseEntity<T>).Id.Equals(Id);
            }

            return base.Equals(obj);
        }

    }
    public abstract class BaseEntity : BaseEntity<long> { 

    }
}
