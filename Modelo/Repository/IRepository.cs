using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int Id);
        void Update(T entity);
        void Commit();
        IQueryable<T> All();
        IQueryable<T> Find(Func<T, bool> predicate);
    }
}
