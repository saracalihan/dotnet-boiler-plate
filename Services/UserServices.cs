using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperExample.Models;
//using DapperExample.Services

namespace DapperExample.Services
{
    public class UserServices
    {
        private SqlConnection connection;
        private AuthenticationService _authService = new AuthenticationService();

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
            var users = connection.Query<User>("select * from users where name=@username", new { username });
            if (users.Count() == 0)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            return users.First();
        }

        public User createUser(string name, bool is_admin, string password)
        {
            //User user = new User(id, name, is_admin);
            HashAndSalt hashAndSalt = _authService.generateSaltAndHash(password);
            var count = connection.Execute(@"insert into users(name, is_admin, password_hash, password_salt) values( @name, @is_admin, @password_hash, @password_salt)", new { name, is_admin, password_hash = hashAndSalt.hash, password_salt = hashAndSalt.salt  });
            if (count != 1)
            {
                throw new Exception("Kullanıcı oluşturulamadı: ");
            }

            return getUserByUsername(name);
        }
        public bool isExist(string username)
        {

            return false;
        }
    }
}
