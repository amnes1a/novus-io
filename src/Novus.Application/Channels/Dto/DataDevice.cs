using System;
using Newtonsoft.Json;

namespace Novus.Channels.Dto
{
    [Serializable]
    public class DataDevice
    {
        [JsonProperty("ApiKey")]
        public string ApiKey { get; set; }
        
        [JsonProperty("DeviceName")]
        public string DeviceName { get; set; }
        
        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}