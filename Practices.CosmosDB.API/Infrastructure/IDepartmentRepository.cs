using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Infrastructure
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<IEnumerable<dynamic>> GetAllActiveDepartmentsAsync();
        Task<dynamic> GetByIdAsync(string id);
        Task<dynamic> InsertAsync(dynamic entity);
        Task<dynamic> UpdateAsync(string id, dynamic entity);
        Task<dynamic> DeleteAsync(string id);
    }
}
