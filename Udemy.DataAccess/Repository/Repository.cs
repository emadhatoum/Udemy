using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.DataAccess;
using Udemy.Repository.IRepository;

namespace Udemy.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //the repository will be the final place where we will intract with dtabase so we have to to do the following
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;// we used the genaric class (t) because we do not know whitch class will call the dbset
        public Repository(ApplicationDbContext db)//So with this, we will be getting the implementation of our database just like we did inside the category
                                                  //Once we have that, we can use that Db to perform the operation.but  since we do the ultimate transaction in db set so we have to add that here
        {

            _db = db;
            this .DbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) //we used for each because we have more than one properties (DbLoggerCategory and coverttype)
                    {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public T getFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            query=query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) //we used for each because we have more than one properties (DbLoggerCategory and coverttype)
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public void ReamoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
