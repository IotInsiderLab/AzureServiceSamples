using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AzureServiceSamples.BlobStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AzureServiceSamples.WebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        private const string FileContentPath = "SampleFiles/test.json";
        private readonly IBlobStorageService _blobStorageService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment, IBlobStorageService blobStorageService)
        {
            _hostingEnvironment = hostingEnvironment;
            _blobStorageService = blobStorageService;
        }
        // GET api/values
        [HttpPost]
        public async Task<IEnumerable<string>> StoreToBlobStorage()
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var fullPath = Path.Combine(contentRootPath, FileContentPath);
            await _blobStorageService.StoreFileAsync(fullPath);
            return new string[] { "Success" };
        }
      
    }
}
