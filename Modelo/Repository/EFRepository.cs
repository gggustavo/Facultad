using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repository
{
    public class EFRepository<T>: IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EFRepository(DbContext dbcontext)
        {
            if (dbcontext == null) throw new ArgumentNullException("dbContext");

            this.Context = dbcontext;
            this.DbSet = Context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int Id)
        {
            T entityDelete = DbSet.Find(Id);
            Delete(entityDelete);
        }

        public void Update(T entity)
        {
           Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> All()
        {
            return DbSet.AsQueryable<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return DbSet.Where(predicate).AsEnumerable();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }


     
    }
}
