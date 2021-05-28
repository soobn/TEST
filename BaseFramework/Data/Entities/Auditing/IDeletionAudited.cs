using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Entities.Auditing
{
    public interface IDeletionAudited
    {
        public DateTime? DeleteAt { set; get; }
    }
}
