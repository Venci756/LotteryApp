using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
    }
}
