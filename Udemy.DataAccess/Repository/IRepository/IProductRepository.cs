using Udemy.Models;
using Udemy.Repository.IRepository;

namespace Udemy.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>//So that a category repository will get all the methods that are implemented inside the genetic repository,

                                                              //   inside that genetic repository, you notice we do not have the method to update.So we need to implement that method and that will be specific to a repository.


    {
     void Update(Product obj);
       
    }
}
