using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.domain;

namespace app.repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void SaveChanges();

        void Delete(T entity);
    }
}
