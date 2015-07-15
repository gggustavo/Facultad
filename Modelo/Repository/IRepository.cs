namespace Modelo.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int Id);
        void Update(T entity);
        void Commit();
        IQueryable<T> Fetch();
        IEnumerable<T> GetAll();
        IQueryable<T> Find(Func<T, bool> predicate);
    }
}
