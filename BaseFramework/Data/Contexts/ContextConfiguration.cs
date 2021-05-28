using BF.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Data.Contexts
{
    public class ContextConfiguration : IConfiguration
    {
        public string Path => "DB";
        public string ConnectionString { set; get; }
        public DbType Type { set; get; } = DbType.MySql;
    }
}
