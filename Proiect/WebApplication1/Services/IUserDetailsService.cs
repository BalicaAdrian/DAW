using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUserDetailsService
    {
        UserDetails GetById(Guid id);
        bool Insert(UserDetails userdetails);
        bool Update(UserDetails userdetails);
        bool Delete(Guid id);
    }
}
