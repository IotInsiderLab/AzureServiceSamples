using AzureServiceSamples.Common;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.CosmosDb
{
    public class CosmosDbService : ICosmosDbService
    {
        private const string DatabaseName = "files";
        private const string CollectionName = "files";

        private readonly IConnectionStringService _connectionStringService;

        private DocumentClient _documentClient;
        private MongoClient _mongoClient;

        public CosmosDbService(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;
        }

        public void Initialize()
        {
            try
            {
                _mongoClient = new MongoClient("mongodb://kresimirscosmosdb:aHiT6nXgU32nadeTiINAWhh4uckimpwJUyltw7kQLps0PKczH2upNPW1slzYYb4IFN42hTVb2EPJcQgRxY5D7Q==@kresimirscosmosdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
                
                _documentClient = new DocumentClient(new Uri(_connectionStringService.CosmosDbEndpoint), _connectionStringService.CosmosDbKey);
            }
            catch(Exception e)
            {
                throw new Exception("Error while initilalization of CosmosDb:\n", e.InnerException);
            }

        }

        public async Task CreateDocumentAsync(object documentContent)
        {
            if (_documentClient == null || _mongoClient == null)
            {
                Initialize();
            }

            try
            {
                await _documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseName), new DocumentCollection { Id = CollectionName });
                
                var database = _mongoClient.GetDatabase(DatabaseName);
                
                var collection = database.GetCollection<object>(CollectionName);
                await collection.InsertOneAsync(documentContent);
            }
            catch (Exception e)
            {
                throw new Exception("Error while creating document:\n", e.InnerException);
            }
        }

    }
}
