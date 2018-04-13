using Autofac;
using AzureServiceSamples.BlobStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AzureServiceSamples.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private const string FileContentPath = "SampleFiles/test.json";

        private readonly IBlobStorageService _blobStorageService;
        public ValuesController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }
        // GET api/values
        public async Task<IEnumerable<string>> StoreToBlobStorage()
        {
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(FileContentPath);
            await _blobStorageService.StoreFileAsync(fullPath);
            return new string[] { "success" };
        }
        
     
    }
}
