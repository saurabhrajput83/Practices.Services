using Microsoft.EntityFrameworkCore;
using Practices.API.DAL.Entities;
using Practices.API.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public class LineItemRepository : ILineItemRepository
    {
        private readonly PracticeDbContext _dbContext;

        public LineItemRepository(PracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LineItem> GetAll()
        {
            return _dbContext.LineItems
                    .Include("Product")
                    .AsEnumerable();
        }

        public IEnumerable<LineItem> GetAllByShoppingCartId(int shoppingCartId)
        {
            return _dbContext.LineItems
                .Include("Product")
                .Where(x => x.ShoppingCartId == shoppingCartId)
                .AsEnumerable();
        }

        public LineItem GetById(int id)
        {
            return _dbContext.LineItems
                .Include("Product")
                .Where(x => x.LineItemId == id)
                .FirstOrDefault();
        }

        public void Insert(LineItem entity)
        {
            var lineItem = _dbContext.LineItems
                .Where(x => x.ShoppingCartId == entity.ShoppingCartId
                && x.ProductId == entity.ProductId)
               .FirstOrDefault();

            if (lineItem != null)
            {
                lineItem.Quantity = lineItem.Quantity + 1;
                _dbContext.LineItems.Update(lineItem);
            }
            else
            {
                _dbContext.LineItems.Add(entity);
            }
        }

        public void Update(LineItem entity)
        {
            _dbContext.LineItems.Update(entity);
        }
        public void Delete(LineItem entity)
        {
            _dbContext.LineItems.Remove(entity);
        }
    }
}
