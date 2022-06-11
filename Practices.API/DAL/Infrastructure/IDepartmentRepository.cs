using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Infrastructure
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        IEnumerable<Department> GetAllActiveDepartments();
        Department GetById(int id);
        void Insert(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
    }
}
