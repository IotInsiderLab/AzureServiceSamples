using AzureServiceSamples.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private const string ContainerReference = "files";
        private const string SourceFile = "SampleFile/test.json";
        private const string FileExtension = ".json";

        private readonly IConnectionStringService _connectionStringService;

        private CloudStorageAccount _storageAccount = null;
        private CloudBlobContainer _cloudBlobContainer = null;

        public BlobStorageService(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;
        }

        public void Initialize()
        {
            var storageConnectionString = _connectionStringService.BlobStorageConnectionString;
            if (CloudStorageAccount.TryParse(storageConnectionString, out _storageAccount))
            {
                try
                {
                    var cloudBlobClient = _storageAccount.CreateCloudBlobClient();
                    
                    _cloudBlobContainer = cloudBlobClient.GetContainerReference(ContainerReference);          
                }
                catch (StorageException e)
                {
                    throw new Exception("An Error occured while initialization of the Blob Storage:\n" + e.Message);
                }
            }
        }

        public async Task StoreFileAsync(string filepath)
        {
            if (_storageAccount == null || _cloudBlobContainer == null)
            {
                Initialize();
            }

            try
            {
                var cloudBlockBlob = _cloudBlobContainer.GetBlockBlobReference(Guid.NewGuid().ToString() + FileExtension);
               
                await cloudBlockBlob.UploadFromFileAsync(filepath);
            }
            catch(Exception e)
            {
                throw new Exception("An Error occured while uploading the file:\n" + e.Message);
            }

        }
    }
}
