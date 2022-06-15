/*
    Veritabanından gelen password hash ve salt bilgileri burada tutulur
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.DTOs.User
{
    public class UserTableDTO : Models.User
    {
        public string password_hash { get; set; }
        public string password_salt { get; set; }
    }
}
