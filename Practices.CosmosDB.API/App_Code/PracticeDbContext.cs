//using Microsoft.Azure.Cosmos;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Practices.CosmosDB.API.App_Code
//{
//    public class Shared
//    {
//        IConfiguration _config;
//        public CosmosClient Client { get; private set; }

//        public Shared(IConfiguration config)
//        {
//            _config = config;
//            string endpointUrl = _config.GetValue<string>("CosmosDB.EndpointUrl");
//            string authKey = _config.GetValue<string>("CosmosDB.EndpointUrl");

//            Client = new CosmosClient(endpointUrl, authKey);
//        }


//    }
//}
