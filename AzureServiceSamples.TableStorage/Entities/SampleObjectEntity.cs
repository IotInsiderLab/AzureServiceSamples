using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.TableStorage
{
    public class SampleObjectEntity : TableEntity
    {
        public string MessageType { get; set; }

        public double Temperature { get; set; }
    }
}
