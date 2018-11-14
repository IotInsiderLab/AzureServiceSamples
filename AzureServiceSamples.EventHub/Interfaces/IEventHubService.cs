using AzureServiceSamples.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceSamples.EventHub
{
    public interface IEventHubService
    {
        Task SendMessageAsync(SampleObject sampleObject);
    }
}
