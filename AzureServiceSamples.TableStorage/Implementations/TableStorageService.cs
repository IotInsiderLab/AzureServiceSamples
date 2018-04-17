using AutoMapper;
using AzureServiceSamples.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceSamples.TableStorage
{
    public class TableStorageService : ITableStorageService
    {
        private static readonly string SampleObjectTableName = "SampleObject";

        private readonly IMapper _mapper;
        private IConnectionStringService _connectionStringService;

        private readonly CloudTable _table;
        private readonly CloudStorageAccount _cloudStorageAccount;

        public TableStorageService(IConnectionStringService connectionStringService, IMapper mapper)
        {
            _mapper = mapper;
            _connectionStringService = connectionStringService;

            _cloudStorageAccount = CloudStorageAccount.Parse(_connectionStringService.BlobStorageConnectionString);

            var client = _cloudStorageAccount.CreateCloudTableClient();
            _table = client.GetTableReference(SampleObjectTableName);
        }

        public async Task<IEnumerable<SampleObject>> GetSampleObjectsAsync()
        {
            TableQuery<SampleObjectEntity> query = new TableQuery<SampleObjectEntity>();

            var items = await _table.ExecuteQueryAsync(query, CancellationToken.None);

            return _mapper.Map<IEnumerable<SampleObject>>(items);
        }

        public async Task<SampleObject> InsertSampleObjectAsync(SampleObject sampleObject)
        {
            var query = new TableQuery<SampleObjectEntity>()
                .Where(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, sampleObject.DeviceId));

           
            var entity = _mapper.Map<SampleObjectEntity>(sampleObject);

            TableOperation insertOperation = TableOperation.Insert(entity);

            await _table.ExecuteAsync(insertOperation);

            return sampleObject;
        }
    }
}
