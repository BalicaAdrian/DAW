using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string email { get; set; }

        public string username { get; set; }
        public string Type { get; set; }
        public string token { get; set; }
    }
}
