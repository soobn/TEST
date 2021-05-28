using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTEntityFrameworkCore.Entities;

namespace TESTEntityFrameworkCore
{
    public interface IRepository<T> where T : BaseEntity,new()
    {
    }
    public interface IRepository<T, TPrimaryKey> where T : BaseEntity<TPrimaryKey>, new()
    {
    }
}
