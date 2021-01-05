using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        User GetById(Guid id);
        User GetByIdAndDetails(Guid id);

        bool Update(User user);

        List<User> GetAll();
        bool Register(AuthenticationRequest request);
        bool Delete(Guid id);

        AuthenticationResponse Login(AuthenticationRequest request);
    }
}
