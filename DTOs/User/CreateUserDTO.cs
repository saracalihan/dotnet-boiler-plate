using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.DTOs.User
{
    public class CreateUserDTO
    {
        public int id { get; set; }
        public string name{ get; set; }
        public bool is_admin { get; set; }
    }
}
