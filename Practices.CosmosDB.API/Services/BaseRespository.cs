using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Services
{
    public class BaseRespository<T> where T : class
    {
        private readonly string _brandsContainerId = "Brands";
        private readonly string _departmentsContainerId = "Departments";
        private readonly string _productsContainerId = "Products";
        public string DatabaseId { get; private set; }
        public CosmosClient Client { get; private set; }

        public Container BrandsContainer
        {
            get
            {
                return Client.GetContainer(DatabaseId, _brandsContainerId);
            }
        }

        public Container DepartmentsContainer
        {
            get
            {
                return Client.GetContainer(DatabaseId, _departmentsContainerId);
            }
        }

        public Container ProductsContainer
        {
            get
            {
                return Client.GetContainer(DatabaseId, _productsContainerId);
            }
        }

        public BaseRespository(IConfiguration config)
        {

            string endpointUrl = config.GetValue<string>("CosmosDB:EndpointUrl");
            string authKey = config.GetValue<string>("CosmosDB:AuthKey");
            DatabaseId = config.GetValue<string>
                ("CosmosDB:DatabaseId");

            Client = new CosmosClient(endpointUrl, authKey);
        }
    }
}
