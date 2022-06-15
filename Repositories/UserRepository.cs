using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public User create(User entity)
        {
            throw new NotImplementedException();
        }


        public User readById(int id)
        {
            throw new NotImplementedException();
        }

        public User update(User entity)
        {
            throw new NotImplementedException();
        }
        public bool deleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
