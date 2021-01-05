using DAWProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(DawAppContext context) : base(context)
        {
        }

        public List<Subscription> GetAllwithChannles()
        {
            return _table.Include(x => x.ModelRelations).ThenInclude(x => x.Channel).ToList();
        }

        public Subscription GetById(Guid id)
        {
            return _table.Where(x => x.Id == id).FirstOrDefault();
        }

        public Subscription GetChannelsToo(Guid id)
        {
            return _table.Where(x => x.Id == id).Include(x => x.ModelRelations).ThenInclude(x =>x.Channel).FirstOrDefault();
           
        }

    }
}
