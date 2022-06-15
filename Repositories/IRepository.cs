using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.Repositories
{
    interface IRepository<T>
    {
        public T create(T entity);
        public T readById(int id);
        public T update(T entity);
        public bool deleteById(int id);
    }
}
