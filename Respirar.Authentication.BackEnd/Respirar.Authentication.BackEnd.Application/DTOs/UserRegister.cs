using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DTOs
{
    public class UserRegister
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool enabled { get; set; }
        public bool admin { get; set; }
        public string image { get; set; }
        public bool gravatar { get; set; }
        public DateTime date_password { get; set; }
        public string description { get; set; }
        public string website { get; set; }


    }
}
