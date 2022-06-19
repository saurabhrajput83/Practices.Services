using Microsoft.EntityFrameworkCore;
using Practices.API.DAL.Entities;
using Practices.API.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly PracticeDbContext _dbContext;

        public ProductRepository(PracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products
                    .Include("Brand")
                    .Include("Department")
                    .AsEnumerable();
        }

        public IEnumerable<Product> GetAllActiveProducts()
        {
            return _dbContext.Products
                .Include("Brand")
                .Include("Department")
                .Where(x => x.IsActive == true)
                .AsEnumerable();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products
                .Include("Brand")
                .Include("Department")
                .Where(x => x.ProductId == id)
                .FirstOrDefault();
        }
        public void Insert(Product entity)
        {
            _dbContext.Products.Add(entity);
        }
        public void Update(Product entity)
        {
            _dbContext.Products.Update(entity);
        }
        public void Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
        }
    }
}
