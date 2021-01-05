using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface ISubscriptionService
    {
        List<Subscription> GetAll();
        Subscription GetById(Guid id);
        bool Insert(Subscription subscription);
        bool Update(Subscription subscription);
        bool Delete(Guid id);

        bool RemoveChannel(ModelRelation paylaod);
        ModelRelation GetChannels(Guid id);

        Subscription GetWithChannles(Guid id);
        List<Subscription> GetAllwithSubscription();
        bool RegisterChannel(ModelRelation paylaod);
    }
}
