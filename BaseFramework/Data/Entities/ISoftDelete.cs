using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Entities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { set; get; }
        public DateTime? DeleteAt { set; get; }
    }
}
