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
        private readonly IBlobStorageService _blobStorageService;
        public ValuesController( )
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BlobStorage.Module>();
            builder.RegisterModule<Common.Module>();
            var container = builder.Build();
            _blobStorageService = container.Resolve<IBlobStorageService>();
        }
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/SampleFiles/test.json");
            await _blobStorageService.StoreFileAsync(fullPath);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
