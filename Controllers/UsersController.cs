using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperExample.Models;
using System.Data.SqlClient;
using DapperExample.DTOs.User;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private SqlConnection connection;

        public UsersController() : base()
        {
            connection = new SqlConnection("Data Source=LAPTOP-POJ47EP4\\SQLEXPRESS01;" + "Initial Catalog=basic;" + "User id=sa;" + "Password=123456;");
            connection.Open();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {

            var users = connection.Query<User>("select * from users", commandType: System.Data.CommandType.Text);
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var res = connection.Query<User>("select * from users where id=@id", new { id = id });
            if(res.Count() ==0)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            return res.First();
        }

        // POST api/<UsersController>
        [HttpPost]
        public User Post(CreateUserDTO userDTO)
        {
            User user = new User(userDTO.id, userDTO.name, userDTO.is_admin);
            var count = connection.Execute(@"insert into users(name, is_admin) values( @name, @is_admin)", user);
            if (count != 1)
            {
                throw new Exception("Kullanıcı oluşturulamadı: ");
            }
            return user;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] UpdateUserDTO userDTO)
        {
            //userDTO.name != null ? "name=@name" : ""

            //userDTO.is_admin = null ? "is_admin=@is_admin" : ""
            return "" + userDTO.name + userDTO.is_admin;
            string query = "update users set name=@name, is_admin=@is_admin where id=@id";
            //
            int count = connection.Execute(query, new { id= id, name = userDTO.name, is_admin=userDTO.is_admin });
            if (count != 1)
            {
                throw new Exception("Kullanıcı oluşturulamadı: ");
            }
            User u = connection.Query<User>("select * from users where id=@id", userDTO).First();
            //return u;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var count = connection.Execute("update users set deleted_at=@now where id=@id", new { id=id, now=DateTime.Now });
            if (count != 1)
            {
                throw new Exception("Kullanıcı silinemedi: "+count);
            }
            return id+ "id'li kullanıcı başarıyla silindi";
        }
    }
}
