using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExample.Constants;

namespace DapperExample.Models
{
    interface IToken
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string value { get; set; }
        public TokenStatus status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime expire_at { get; set; }

        public bool expire()
        {
            return true;
        }
    }
}
