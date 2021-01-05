using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Model
{
    public class User : BaseEntity
    {
        public string email { get; set; }
        public string password { get; set; }

        public string username { get; set; }
        public UserDetails UserDetails { get; set; }
        public string Type { get; set; }

        public Subscription Subscription { get; set; }
        public Guid? SubscriptionId { get; set; }
    }
}
