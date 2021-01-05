using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
   public interface IChannelService
    {
        List<Channel> GetAll();

        Channel GetById(Guid id);
        bool Insert(Channel channel);
        bool Update(Channel channel);
        bool Delete(Guid id);
    }
}
