using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTEntityFrameworkCore.Entities;

namespace TESTEntityFrameworkCore
{
    public class SugarDatabase
    {
        private readonly SugarDatabaseConfiguration _sugarDatabaseConfiguration;
        private readonly SqlSugarClient _db;

        public SugarDatabase(SugarDatabaseConfiguration sugarDatabaseConfiguration) {
            _sugarDatabaseConfiguration = sugarDatabaseConfiguration;
            _db = CreateClient();
        }
        private SqlSugarClient CreateClient() {

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _sugarDatabaseConfiguration.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

        public ISugarQueryable<T> Set<T>() {
            return _db.Queryable<T>();
        }
        public T Insert<T>(T entity) where T:class,new() {
            var insertable= _db.Insertable(entity);
            return  insertable.ExecuteReturnEntity();
        }
        public bool Update<T>(T entity) where T : class, new()
        {
            var updateable = _db.Updateable(entity);
            return updateable.ExecuteCommand()>0;
        }
        public bool Delete<T>(T entity) where T : class, new()
        {
            if (entity is ISoftDeleted)
            {
                var softDeleted = (entity as ISoftDeleted);
                softDeleted.IsDeleted = true;
                softDeleted.DeleteAt = DateTime.Now;
                return Update(entity);
            }
            else
            {
                var deleteable = _db.Deleteable(entity);
                return deleteable.ExecuteCommand() > 0;
            }
        }
        public int SaveChange()
        {
            return _db.SaveQueues();
        }
        public Task<int> SaveChangeAsync()
        {
            return _db.SaveQueuesAsync();
        }
    }
}
