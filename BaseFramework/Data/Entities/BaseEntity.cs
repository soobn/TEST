using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Entities
{
    public class BaseEntity<T> where T:struct
    {
        public T Id { set; get; }
        public override string ToString()
        {
            return $"{GetType().Name}_{Id}";
        }
    }
    public class BaseEntity :BaseEntity<Guid>{ 

    }
}
