using Practices.API.DAL.Entities;
using Practices.API.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public class BrandRepository : IBrandRepository
    {
        private readonly PracticeDbContext _dbContext;

        public BrandRepository(PracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _dbContext.Brands
                    .AsEnumerable();
        }

        public IEnumerable<Brand> GetAllActiveBrands()
        {
            return _dbContext.Brands
                .Where(x => x.IsActive == true)
                      .AsEnumerable();
        }

        public Brand GetById(int id)
        {
            return _dbContext.Brands
                .Where(x => x.BrandId == id)
                .FirstOrDefault();
        }
        public void Insert(Brand entity)
        {
            _dbContext.Brands.Add(entity);
        }
        public void Update(Brand entity)
        {
            _dbContext.Brands.Update(entity);
        }
        public void Delete(Brand entity)
        {
            _dbContext.Brands.Remove(entity);
        }
    }
}
