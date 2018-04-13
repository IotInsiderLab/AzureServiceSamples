using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string BlobStorageConnectionString => "blob_storage_connection_string_here";
    }
}
