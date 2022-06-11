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
        public string DatabaseId { get; private set; }
        public CosmosClient Client { get; private set; }

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
