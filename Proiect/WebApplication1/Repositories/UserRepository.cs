using DAWProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Repositories;
using System.Threading.Tasks;
using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(DawAppContext context) : base(context)
        {
        }

        public User GetByUserAndPassword(string username, string password)
        {
            return _table.Where(x => x.username == username && x.password == password && !x.IsDeleted).FirstOrDefault();
        }

        public User GetUserWithDetails(Guid id)
        {
            return _table.Where(x => x.Id == id)
                .Include(x => x.UserDetails)
                .Include(x  => x.Subscription)
                .FirstOrDefault();
        }
    }
}
