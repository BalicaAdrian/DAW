using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public interface IUserRepository :IGenericRepository<User>
    {
        User GetByUserAndPassword(string username, string password);
        User GetUserWithDetails(Guid id);
    }
}
