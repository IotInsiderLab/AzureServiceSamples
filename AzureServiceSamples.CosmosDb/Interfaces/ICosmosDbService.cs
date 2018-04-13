using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.CosmosDb
{
    public interface ICosmosDbService
    {
        void Initialize();

        Task CreateDocumentAsync(dynamic documentContent);
    }
}
