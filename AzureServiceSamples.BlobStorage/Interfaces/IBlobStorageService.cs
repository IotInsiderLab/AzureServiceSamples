using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.BlobStorage
{
    public interface IBlobStorageService
    {
        void Initialize();
        Task StoreFileAsync(string filePath);
    }
}
