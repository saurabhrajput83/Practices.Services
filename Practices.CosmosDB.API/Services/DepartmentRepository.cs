using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Practices.CosmosDB.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Services
{
    public class DepartmentRepository : 
        BaseRespository<DepartmentRepository>, IDepartmentRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DepartmentRepository> _logger;
   
        public DepartmentRepository(
            IConfiguration config,
            ILogger<DepartmentRepository> logger) : base(config)
        {
            _config = config;
            _logger = logger;
        }

        

        public async Task<dynamic> DeleteAsync(string id)
        {
            ItemResponse<dynamic> response = await DepartmentsContainer.DeleteItemAsync<dynamic>(id,
                new PartitionKey(id));
            return response.Resource;
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            string queryText = "select * from c";
            var itemsIterator = DepartmentsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync(CancellationToken.None);
            IList<dynamic> itemsList = new List<dynamic>();

            foreach (var document in documents)
            {
                itemsList.Add(document);
            }

            return itemsList;
        }

        public async Task<IEnumerable<dynamic>> GetAllActiveDepartmentsAsync()
        {
            string queryText = "SELECT * FROM c where c.isActive = true";
            var itemsIterator = DepartmentsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync();
            IList<dynamic> itemsList = new List<dynamic>();

            foreach (var document in documents)
            {
                itemsList.Add(document);
            }

            return itemsList;

        }

        public async Task<dynamic> GetByIdAsync(string id)
        {
            string queryText = "SELECT * FROM c where c.id = '" + id + "'";
            var itemsIterator = DepartmentsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync();

            return documents.FirstOrDefault();
        }

        public async Task<dynamic> InsertAsync(dynamic entity)
        {
            Guid id = Guid.NewGuid();
            entity.id = id;

            ItemResponse<dynamic> response = await DepartmentsContainer.CreateItemAsync<dynamic>(entity,
                 new PartitionKey(id.ToString()));

            return response.Resource;
        }

        public async Task<dynamic> UpdateAsync(string id, dynamic entity)
        {
            ItemResponse<dynamic> response = await DepartmentsContainer.UpsertItemAsync<dynamic>(entity,
                  new PartitionKey(id));
            return response.Resource;
        }
    }
}
