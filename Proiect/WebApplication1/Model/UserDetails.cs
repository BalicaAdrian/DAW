using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Model
{
    public class UserDetails: BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
