using BF.Dependency;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Contexts
{
    public class EntityContext:IScopedDependency
    {
        public ISqlSugarClient Client { get; }
        public EntityContext(ContextConfiguration configuration) {
            Client = CreateClient(configuration);
        }

        private ISqlSugarClient CreateClient(ContextConfiguration configuration)
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = configuration.ConnectionString,
                DbType = configuration.Type,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
    }
}
