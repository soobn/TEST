using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTEntityFrameworkCore.Entities;

namespace TESTEntityFrameworkCore
{
    public class EntityRepository<T, TPrimaryKey> :IRepository<T, TPrimaryKey>
        where T:BaseEntity<TPrimaryKey>,new()
        where TPrimaryKey:struct
    {
        private readonly SugarDatabase _database;

        public ISugarQueryable<T> Queryable => _database.Set<T>();

        public EntityRepository(SugarDatabase database) {
            _database = database;
        }

        public T FindById(TPrimaryKey id) {
            return Queryable.Single(x => x.Id.Equals(id));
        }
        public T Insert(T entity)
        {
            return _database.Insert(entity);
        }
        public bool Update(T entity)
        {
            return _database.Update(entity);
        }
        public bool Delete(T entity)
        {
            return _database.Delete(entity);
        }
    }
}
