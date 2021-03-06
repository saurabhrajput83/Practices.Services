using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        IEnumerable<Brand> GetAllActiveBrands();
        Brand GetById(int id);
        void Insert(Brand entity);
        void Update(Brand entity);
        void Delete(Brand entity);
    }
}
