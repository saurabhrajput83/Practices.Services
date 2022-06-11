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
        public readonly IProductRepository _productRepository;

        public UnitOfWork(PracticeDbContext dbContext,
            IBrandRepository brandRepository,
            IDepartmentRepository departmentRepository,
            IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _brandRepository = brandRepository;
            _departmentRepository = departmentRepository;
            _productRepository = productRepository;
        }

        public IBrandRepository BrandRepository
        {
            get { return _brandRepository; }
        }
        public IDepartmentRepository DepartmentRepository
        {
            get { return _departmentRepository; }
        }
        public IProductRepository ProductRepository
        {
            get { return _productRepository; }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
