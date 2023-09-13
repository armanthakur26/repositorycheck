using imageupload.Data;
using imageupload.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace imageupload.Repository
{
    public class Repository<T> : Irepository<T> where T : class
    {
        private readonly Applicationdbcontext _context;
        internal DbSet<T> _dbSet;
        public Repository(Applicationdbcontext context)
        {
            _context=context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
           _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public T get(int id)
        {

            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (Filter != null)
                query = _dbSet.Where(Filter);
            if (includeProperties != null)// multipal table say data example category,covertype
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (orderBy != null)
                return orderBy(query).ToList();
            return query.ToList();
        }

        public void remove(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public void Update(T entity)
        {
            _context.ChangeTracker.Clear();
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
