using DAWProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DawAppContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(DawAppContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;
            _context.Set<T>().Add(entity);
        }

        public void CreateRange(List<T> entities)
        {
            entities.ForEach(x =>
            {
                x.DateCreated = DateTime.UtcNow;
                x.DateUpdated = DateTime.UtcNow;
            });

            _table.AddRange(entities);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void HardDelete(T entity)
        {
            _table.Remove(entity);
        }

        public T FindById(Guid id)
        {
            return _table.Find(id);
        }

        public List<T> GetAllActive()
        {
            return _table.Where(x => !x.IsDeleted).ToList();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            _table.Update(entity);
        }
    }
}

