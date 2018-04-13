using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string BlobStorageConnectionString => "";

        public string CosmosDbEndpoint => "";

        public string CosmosDbKey => "";
    }
}
