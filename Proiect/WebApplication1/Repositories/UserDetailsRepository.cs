using DAWProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class UserDetailsRepository : GenericRepository<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(DawAppContext context) : base(context)
        {
        }
        public UserDetails GetById(Guid id)
        {
            return _table.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
