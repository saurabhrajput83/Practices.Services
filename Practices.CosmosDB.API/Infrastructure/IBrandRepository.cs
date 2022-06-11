using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Infrastructure
{
    public interface IBrandRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<IEnumerable<dynamic>> GetAllActiveBrandsAsync();
        Task<dynamic> GetByIdAsync(string id);
        Task<dynamic> InsertAsync(dynamic entity);
        Task<dynamic> UpdateAsync(string id, dynamic entity);
        Task<dynamic> DeleteAsync(string id);
    }
}
