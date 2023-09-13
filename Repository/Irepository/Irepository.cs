using System.Linq.Expressions;

namespace imageupload.Repository.Irepository
{
    public interface Irepository<T> where T : class
        // t is represent the class or model which have more reusable and flexible code that can work with different types of data.
    {
        void Add(T entity);//post data
         T get(int id);//get by id
        void remove(int id);//delete
        void Update(T entity);//put update

        IEnumerable<T> GetAll(
           Expression<Func<T, bool>> Filter = null,//filter
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,// for sorting
          string includeProperties = null// for fetch multipal table data
           );
        // IEnumerable<T> GetAll(T entity);

        // Task<List<T>> GetAll();
    }
}
