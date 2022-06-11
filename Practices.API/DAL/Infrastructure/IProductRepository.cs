using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllActiveProducts();
        Product GetById(int id);
        void Insert(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
