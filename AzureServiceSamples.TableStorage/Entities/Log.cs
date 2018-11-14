using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.TableStorage
{
    public class Log : TableEntity
    {
        public string DeviceId { get; set; }

        public string LogLevel { get; set; }

        public long SequenceCounter { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public int Version { get; set; }
    }
}
