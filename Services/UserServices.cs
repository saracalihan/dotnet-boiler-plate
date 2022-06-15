using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DapperExample.Models;
using Dapper;

namespace DapperExample.Services
{
    public class UserServices
    {
        private SqlConnection connection;

        public UserServices()
        {
            connection = new SqlConnection("Data Source=LAPTOP-POJ47EP4\\SQLEXPRESS01;" + "Initial Catalog=basic;" + "User id=sa;" + "Password=123456;");
            connection.Open();
        }
        public User getUserById(int id)
        {
            var users = connection.Query<User>("select * from users where id=@id", new { id });
            return users.First();
        }
        public User getUserByUsername(string username)
        {
            var users = connection.Query<User>("select * from users where name=@username", new { name = username });
            if (users.Count() == 0)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            return users.First();
        }

        public User createUser(string name, bool is_admin)
        {
            //User user = new User(id, name, is_admin);
            var count = connection.Execute(@"insert into users(name, is_admin) values( @name, @is_admin)", new { name, is_admin });
            if (count != 1)
            {
                throw new Exception("Kullanıcı oluşturulamadı: ");
            }

            return getUserByUsername(name);
        }
        static public bool isExist(string username)
        {

            return false;
        }
    }
}
