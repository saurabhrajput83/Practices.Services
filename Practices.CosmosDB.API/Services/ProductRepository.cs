//using Practices.CosmosDB.API.App_Code;
//using Practices.CosmosDB.API.Infrastructure;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Practices.CosmosDB.API.Services
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly PracticeDbContext _dbContext;

//        public ProductRepository(PracticeDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Product> GetAll()
//        {
//            return _dbContext.Products
//                    .AsEnumerable();
//        }

//        public IEnumerable<Product> GetAllActiveProducts()
//        {
//            return _dbContext.Products
//                .Where(x => x.IsActive == true)
//                .AsEnumerable();
//        }

//        public Product GetById(int id)
//        {
//            return _dbContext.Products
//                .Where(x => x.ProductId == id)
//                .FirstOrDefault();
//        }
//        public void Insert(Product entity)
//        {
//            _dbContext.Products.Add(entity);
//        }
//        public void Update(Product entity)
//        {
//            _dbContext.Products.Update(entity);
//        }
//        public void Delete(Product entity)
//        {
//            _dbContext.Products.Remove(entity);
//        }
//    }
//}
