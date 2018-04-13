﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public interface IConnectionStringService
    {
        string BlobStorageConnectionString { get; }
        string CosmosDbEndpoint { get; }
        string CosmosDbKey { get; }
    }
}
