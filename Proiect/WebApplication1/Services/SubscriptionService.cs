using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IModelRelationRepository _relationRepository;

        public SubscriptionService(ISubscriptionRepository repository, IModelRelationRepository relationRepository)
        {
            this._repository = repository;
            this._relationRepository = relationRepository;
        }

        public List<Subscription> GetAll()
        {
            return _repository.GetAllActive();
        }

        public bool Delete(Guid id)
        {
            var subscription = _repository.FindById(id);
            _repository.Delete(subscription);
            return _repository.SaveChanges();
        }

        public Subscription GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(Subscription subscription)
        {
            _repository.Create(subscription);
            return _repository.SaveChanges();
        }

        public bool Update(Subscription subscription)
        {
            _repository.Update(subscription);
            return _repository.SaveChanges();
        }

        public bool RegisterChannel(ModelRelation paylaod)
        {

            _relationRepository.Create(paylaod);
            return _relationRepository.SaveChanges();
        }

        public bool RemoveChannel(ModelRelation paylaod)
        {

            var relation = _relationRepository.RemoveChannel(paylaod);
            return _repository.SaveChanges();
           
        }

        public ModelRelation GetChannels(Guid id)
        {
            return _relationRepository.GetChannels(id);
        }

        public Subscription GetWithChannles(Guid id)
        {
            return _repository.GetChannelsToo(id);
        }

        public List<Subscription> GetAllwithSubscription()
        {
            return _repository.GetAllwithChannles();
        }
    }
}
