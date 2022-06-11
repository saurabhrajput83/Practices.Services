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
        Task<IEnumerable<dynamic>> GetAll();
        Task<IEnumerable<dynamic>> GetAllActiveBrands();
        Task<dynamic> GetById(string id);
        Task<dynamic> Insert(dynamic entity);
        Task<dynamic> Update(string id, dynamic entity);
        Task<dynamic> Delete(string id);
    }
}
