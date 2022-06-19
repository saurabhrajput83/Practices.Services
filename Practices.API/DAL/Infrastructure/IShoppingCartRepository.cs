using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCart> GetAll();
        ShoppingCart GetById(int id);
        void Insert(ShoppingCart entity);
        void Update(ShoppingCart entity);
        void Delete(ShoppingCart entity);
    }
}
