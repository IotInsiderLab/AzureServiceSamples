using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AzureServiceSamples.BlobStorage;
using AzureServiceSamples.Common;
using AzureServiceSamples.CosmosDb;
using AzureServiceSamples.TableStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace AzureServiceSamples.WebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        private const string FileContentPath = "SampleFiles/test.json";

        private readonly IBlobStorageService _blobStorageService;
        private readonly ICosmosDbService _cosmosDbService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ITableStorageService _tableStorageService;

        public ValuesController(IHostingEnvironment hostingEnvironment, 
            IBlobStorageService blobStorageService,
            ICosmosDbService cosmosDbService,
            ITableStorageService tableStorageService)
        {
            _hostingEnvironment = hostingEnvironment;
            _blobStorageService = blobStorageService;
            _cosmosDbService = cosmosDbService;
            _tableStorageService = tableStorageService;
        }
        // Post api/values/storetoblobstorage
        [HttpPost]
        public async Task<IEnumerable<string>> StoreToBlobStorage()
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var fullPath = Path.Combine(contentRootPath, FileContentPath);
            await _blobStorageService.StoreFileAsync(fullPath);
            return new string[] { "Success" };
        }

        // Post api/values/storetocosmosdb
        [HttpPost]
        public async Task<IEnumerable<string>> StoreToCosmosDb([FromBody]dynamic documentContent)
        {
            //TODO replace dynamic with conrete type in order to make it working
            var id = Guid.NewGuid();
            documentContent.id = id;
            await _cosmosDbService.CreateDocumentAsync(documentContent);
            return new string[] { "Success" };
        }

        // Post api/values/storetotablestorage
        [HttpPost]
        public async Task<SampleObject> StoreToTableStorage([FromBody]SampleObject sampleObject)
        {
            var result = await _tableStorageService.InsertSampleObjectAsync(sampleObject);
            return result;
        }

        // Post api/values/gertablestorageitems
        [HttpGet]
        public async Task<IEnumerable<SampleObject>> GetTableStorageItems()
        {
            var result = await _tableStorageService.GetSampleObjectsAsync();
            return result;
        }

    }
}
