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
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var fullPath = Path.Combine(contentRootPath, FileContentPath);
             await _blobStorageService.StoreFileAsync(fullPath);
            return new string[] { "Success" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
