using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string StorageConnectionString => "your_connection_string_here";

        public string CosmosDbEndpoint => "";

        public string CosmosDbKey => "";
    }
}
