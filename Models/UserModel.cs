using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DapperExample.Services;

namespace DapperExample.Models
{
    public class User
    {

        public int id { get; set; }
        public string name { get; set; }
        public bool is_admin { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }

        // TODO: salt ve hash kullanıcıya dönülmemesi için DTOs/User/UserTable.cs içine taşınmalı
        public string password_hash { get; set; }
        public string password_salt { get; set; }

        public User() { }
        public User(int id, string name, bool is_admin = false)
        {
            this.id = id;
            this.name = name;
            this.is_admin = is_admin;
            this.created_at = DateTime.Now;
            updated_at = null;
            deleted_at = null;

        }

        public Object removeSensitiveFields()
        {

            return new { id, name, is_admin, created_at, updated_at, deleted_at };
        }

        public string toJSON()
        {
            return JsonSerializer.Serialize(removeSensitiveFields());
        }

        private bool setPasswordHashNSalt(string password)
        {
            AuthenticationService _authService = new AuthenticationService();
            HashAndSalt HashNSalt = _authService.generateSaltAndHash(password);
            password_hash = HashNSalt.hash;
            password_salt = HashNSalt.salt;
            return true;
        }
    }
}
