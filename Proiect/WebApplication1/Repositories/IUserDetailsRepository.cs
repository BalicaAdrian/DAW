using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public interface IUserDetailsRepository : IGenericRepository<UserDetails>
    {
        UserDetails GetById(Guid id);
    }
}
