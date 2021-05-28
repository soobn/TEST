using BF.Data.Contexts;
using BF.Data.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Repostories
{
    public class EntityRepository<TModel, TPrimaryKey> : IRepository<TModel, TPrimaryKey>
        where TModel : BaseEntity<TPrimaryKey>,new ()
        where TPrimaryKey : struct
    {
        private readonly EntityContext _entityContext;
        public ISugarQueryable<TModel> Queryable => _entityContext.Client.Queryable<TModel>();

        public EntityRepository(EntityContext entityContext) {
            _entityContext = entityContext;
        }

        public bool Any(Expression<Func<TModel, bool>> expression)
        {
             return Queryable.Where(expression).Any();
        }

        public TModel Insert(TModel entity)
        {
            var insertable = _entityContext.Client.Insertable(entity);
            return insertable.ExecuteReturnEntity();
        }
        public Task<TModel> InsertAsync(TModel entity)
        {
            var insertable = _entityContext.Client.Insertable(entity);
            return insertable.ExecuteReturnEntityAsync();
        }
    }
}
