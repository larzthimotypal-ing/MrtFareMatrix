using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.domain;
using Microsoft.EntityFrameworkCore;

namespace app.repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> entities;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Create(T entity)
        {
            entities.Add(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
