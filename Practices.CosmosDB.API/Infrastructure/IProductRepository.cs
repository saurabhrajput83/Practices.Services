using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Infrastructure
{
    public interface IProductRepository
    {
        IEnumerable<object> GetAll();
        IEnumerable<object> GetAllActiveProducts();
        object GetById(int id);
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
    }
}
