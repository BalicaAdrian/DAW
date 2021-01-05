using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class AuthenticationRequest
    {
      
        public string username { get; set; }
        public string email { get; set; }

        public string password { get; set; }

    }
}
