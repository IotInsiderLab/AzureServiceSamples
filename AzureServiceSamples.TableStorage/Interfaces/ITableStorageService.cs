using AzureServiceSamples.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.TableStorage
{
    public interface ITableStorageService
    {
        Task<IEnumerable<SampleObject>> GetSampleObjectsAsync();

        Task<SampleObject> InsertSampleObjectAsync(SampleObject sampleObject);
    }
}
