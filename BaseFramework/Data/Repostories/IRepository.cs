using BF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Repostories
{
    public interface IRepository<TModel, TPrimaryKey>
        where TModel : BaseEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        TModel Insert(TModel entity);
        Task<TModel> InsertAsync(TModel entity);
        bool Any(Expression<Func<TModel, bool>> expression);
    }
}
