using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAllActive();
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);
        void CreateRange(List<T> entities);

        T FindById(Guid id);

        bool SaveChanges();
    }
}
