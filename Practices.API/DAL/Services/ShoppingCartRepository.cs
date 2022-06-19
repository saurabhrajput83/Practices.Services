using Practices.API.DAL.Entities;
using Practices.API.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly PracticeDbContext _dbContext;

        public ShoppingCartRepository(PracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCarts
                    .AsEnumerable();
        }

        public ShoppingCart GetById(int id)
        {
            return _dbContext.ShoppingCarts
                .Where(x => x.ShoppingCartId == id)
                .FirstOrDefault();
        }
        public void Insert(ShoppingCart entity)
        {
            _dbContext.ShoppingCarts.Add(entity);
        }
        public void Update(ShoppingCart entity)
        {
            _dbContext.ShoppingCarts.Update(entity);
        }
        public void Delete(ShoppingCart entity)
        {
            _dbContext.ShoppingCarts.Remove(entity);
        }
    }
}
