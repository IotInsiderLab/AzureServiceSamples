using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public interface IConnectionStringService
    {
        string StorageConnectionString { get; }

        string CosmosDbEndpoint { get; }

        string CosmosDbKey { get; }
    }
}
