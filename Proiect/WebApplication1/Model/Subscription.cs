using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Model
{
    public class Subscription:BaseEntity
    {
        public string name { get; set; }
        public float price { get; set; }
        public int period { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<ModelRelation> ModelRelations { get; set; }
    }
}
