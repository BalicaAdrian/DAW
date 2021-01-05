using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Model
{
    public class ModelRelation :BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
