using Practices.API.DAL.Entities;
using Practices.API.DAL.Infrastructure;
using Practices.API.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly PracticeDbContext _dbContext;
        public readonly IBrandRepository _brandRepository;
        public readonly IDepartmentRepository _departmentRepository;
        public readonly ILineItemRepository _lineItemRepository;
        public readonly IProductRepository _productRepository;
        public readonly IShoppingCartRepository _shoppingCartRepository;

        public UnitOfWork(PracticeDbContext dbContext,
            IBrandRepository brandRepository,
            IDepartmentRepository departmentRepository,
            ILineItemRepository lineItemRepository,
            IProductRepository productRepository,
            IShoppingCartRepository shoppingCartRepository)
        {
            _dbContext = dbContext;
            _brandRepository = brandRepository;
            _departmentRepository = departmentRepository;
            _lineItemRepository = lineItemRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IBrandRepository BrandRepository
        {
            get { return _brandRepository; }
        }
        public IDepartmentRepository DepartmentRepository
        {
            get { return _departmentRepository; }
        }

        public ILineItemRepository LineItemRepository
        {
            get { return _lineItemRepository; }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository; }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get { return _shoppingCartRepository; }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
