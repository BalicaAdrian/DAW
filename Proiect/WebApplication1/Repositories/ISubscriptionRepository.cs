using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Subscription GetById(Guid id);

        List<Subscription> GetAllwithChannles();

        Subscription GetChannelsToo(Guid id);

    }
}
