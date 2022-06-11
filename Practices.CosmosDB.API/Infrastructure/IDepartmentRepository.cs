using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Infrastructure
{
    public interface IDepartmentRepository
    {
        IEnumerable<object> GetAll();
        IEnumerable<object> GetAllActiveDepartments();
        object GetById(int id);
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
    }
}
