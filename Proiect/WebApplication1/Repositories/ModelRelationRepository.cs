using DAWProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ModelRelationRepository : GenericRepository<ModelRelation>, IModelRelationRepository
    {
        public ModelRelationRepository(DawAppContext context) : base(context)
        {

        }
        public ModelRelation GetChannels(Guid subscription)
        {
            return _table.Where(x => x.SubscriptionId == subscription).Include(x => x.Channel).FirstOrDefault();
        }

        public bool RemoveChannel(ModelRelation payload)
        {
            var obj = _table.Where(x => x.SubscriptionId == payload.SubscriptionId && x.ChannelId == payload.ChannelId).ToList();
            obj.ForEach(x =>
            {
                {
                    x.IsDeleted = true;
                    Update(x);
                }
            });
            return true;
        }
    }
}
