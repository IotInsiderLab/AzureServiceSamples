using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.Common
{
    public class SampleObject
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("messageType")]
        public string MessageType { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("ticks")]
        public long Ticks { get; set; }
    }
}
