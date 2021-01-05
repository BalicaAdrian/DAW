using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class UserDetailsService : IUserDetailsService
    {

        private readonly IUserDetailsRepository _repository;
        public UserDetailsService(IUserDetailsRepository repository)
        {
            this._repository = repository;
        }
        public bool Delete(Guid id)
        {
            var userdetails = _repository.FindById(id);
            _repository.Delete(userdetails);
            return _repository.SaveChanges();
        }

        public UserDetails GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(UserDetails userdetails)
        {
            _repository.Create(userdetails);
            return _repository.SaveChanges();   
        }

        public bool Update(UserDetails userdetails)
        {
            _repository.Update(userdetails);
            return _repository.SaveChanges();
        }
    }
}
