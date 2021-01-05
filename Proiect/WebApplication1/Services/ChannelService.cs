using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _repository;
        public ChannelService(IChannelRepository repository)
        {
            this._repository = repository;
        }

        public List<Channel> GetAll()
        {
            return _repository.GetAllActive();

        }
        public bool Delete(Guid id)
        {

            var channel = _repository.FindById(id);
            _repository.Delete(channel);
            return _repository.SaveChanges();
        }

        public Channel GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(Channel channel)
        {
            _repository.Create(channel);
            return _repository.SaveChanges();
        }

        public bool Update(Channel channel)
        {
            _repository.Update(channel);
            return _repository.SaveChanges();
        }
    }
}
