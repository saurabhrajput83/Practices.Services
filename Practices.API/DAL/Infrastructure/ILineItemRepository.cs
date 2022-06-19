using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface ILineItemRepository
    {
        IEnumerable<LineItem> GetAll();
        IEnumerable<LineItem> GetAllByShoppingCartId(int shoppingCartId);
        LineItem GetById(int id);
        void Insert(LineItem entity);
        void Update(LineItem entity);
        void Delete(LineItem entity);
    }
}
