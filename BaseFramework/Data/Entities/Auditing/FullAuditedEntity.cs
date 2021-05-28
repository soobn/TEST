using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Entities.Auditing
{
    public class FullAuditedEntity<T> : BaseEntity<T>, ICreationAudited, IModificationAudited, IDeletionAudited, ISoftDelete where T : struct
    {
        public DateTime CreateAt { set; get; }
        public DateTime? UpdateAt { set; get; }
        public DateTime? DeleteAt { set; get; }
        public bool IsDeleted { set; get; }
    }
    public class FullAuditedEntity :FullAuditedEntity<Guid>{ }
}
