using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Model
{
    public class Channel :BaseEntity
    {

        public string name { get; set; }
        public string tip { get; set; }
        public string origine { get; set; }

        public ICollection<ModelRelation> ModelRelations { get; set; }
    }
}
