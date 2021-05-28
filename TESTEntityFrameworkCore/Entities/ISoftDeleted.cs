using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTEntityFrameworkCore.Entities
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { set; get; }
        public DateTime? DeleteAt { set; get; }
    }
}
