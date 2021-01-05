using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public interface IModelRelationRepository : IGenericRepository<ModelRelation>
    {
        ModelRelation GetChannels(Guid subscription);
        bool RemoveChannel(ModelRelation payload);
    }
}
