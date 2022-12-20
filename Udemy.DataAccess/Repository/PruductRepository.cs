using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.DataAccess.Repository.IRepository;
using Udemy.Models;
using Udemy.Repository;

namespace Udemy.DataAccess.Repository
{
    public class PruductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public PruductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

               public void Update(Product obj)
        {
            var objFromDb =_db.Product.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title=obj.Title;
                objFromDb.Description=obj.Description;
                objFromDb.Price=obj.Price;
                objFromDb.ListPrice=obj.ListPrice;
                objFromDb.CategoryId=obj.CategoryId;
                objFromDb.Author=obj.Author;
                objFromDb.ISBN=obj.ISBN;
                objFromDb.ListPrice50=obj.ListPrice50;
                objFromDb.ListPrice100=obj.ListPrice100;
                objFromDb.CoverTypeId=obj.CoverTypeId;
                if(obj.ImageUrl!=null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }

            }
        }

        
    }
}
