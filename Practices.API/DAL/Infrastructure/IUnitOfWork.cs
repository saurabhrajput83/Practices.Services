using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        IBrandRepository BrandRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ILineItemRepository LineItemRepository { get; }
        IProductRepository ProductRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        void SaveChanges();
    }
}
