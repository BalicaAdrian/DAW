using DAWProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ChannelRepository : GenericRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(DawAppContext context) : base(context)
        {
        }

        public Channel GetById(Guid id)
        {
            return _table.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
