using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Practices.CosmosDB.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Services
{


    public class BrandRepository : BaseRespository<BrandRepository>, IBrandRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<BrandRepository> _logger;
        private readonly string _containerId = "Brands";
      
        public BrandRepository(
            IConfiguration config,
            ILogger<BrandRepository> logger) : base(config)
        {
            _config = config;
            _logger = logger;
        }

        public Container BrandsContainer
        {
            get
            {
                return Client.GetContainer(DatabaseId, _containerId);
            }
        }

        public async Task<dynamic> Delete(string id)
        {
            ItemResponse<dynamic> response = await BrandsContainer.DeleteItemAsync<dynamic>(id,
                new PartitionKey(id));
            return response.Resource;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            string queryText = "select * from c";
            var itemsIterator = BrandsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync(CancellationToken.None);
            IList<dynamic> itemsList = new List<dynamic>();

            foreach (var document in documents)
            {
                itemsList.Add(document);
            }

            return itemsList;
        }

        public async Task<IEnumerable<dynamic>> GetAllActiveBrands()
        {
            string queryText = "SELECT * FROM c where c.isActive = true";
            var itemsIterator = BrandsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync();
            IList<dynamic> itemsList = new List<dynamic>();

            foreach (var document in documents)
            {
                itemsList.Add(document);
            }

            return itemsList;

        }

        public async Task<dynamic> GetById(string id)
        {
            string queryText = "SELECT * FROM c where c.id = '" + id + "'";
            var itemsIterator = BrandsContainer.GetItemQueryIterator<dynamic>(queryText);
            var documents = await itemsIterator.ReadNextAsync();

            return documents.FirstOrDefault();
        }

        public async Task<dynamic> Insert(dynamic entity)
        {
            Guid id = Guid.NewGuid();
            entity.id = id;

            ItemResponse<dynamic> response = await BrandsContainer.CreateItemAsync<dynamic>(entity,
                 new PartitionKey(id.ToString()));

            return response.Resource;
        }

        public async Task<dynamic> Update(string id,dynamic entity)
        {
            ItemResponse<dynamic> response = await BrandsContainer.UpsertItemAsync<dynamic>(entity,
                  new PartitionKey(id));
            return response.Resource;
        }
    }
}
