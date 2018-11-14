using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureServiceSamples.Common;
using Microsoft.ServiceBus.Messaging;

namespace AzureServiceSamples.EventHub
{
    public class EventHubService : IEventHubService
    {
        private EventHubClient _eventHubClient;
        private QueueClient _queueClient;

        public Task SendMessageAsync(SampleObject sampleObject)
        {
            //_queueClient.SendBatchAsync()
            return null;
        }
    }
}
