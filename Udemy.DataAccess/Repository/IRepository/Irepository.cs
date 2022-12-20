using System.Linq.Expressions;

namespace Udemy.Repository.IRepository
{
    public interface IRepository<T>where T : class
    {
  T getFirstOrDefault (Expression<Func<T, bool>> filter,string? includeProperties = null);
        IEnumerable<T> GetAll(string? includeProperties = null); // this will retreve all the categories
      
        void Add(T entity);
        void Remove(T entity);
        void ReamoveRange(IEnumerable<T> entity);
        

    }
}
