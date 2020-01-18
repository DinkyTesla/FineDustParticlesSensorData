using Newtonsoft.Json;
using System.Collections.Generic;

namespace FineDustParticlesSensorData.Data.Models
{
    class ResponseData
    {
        [JsonProperty(PropertyName = "timestamp")]
        public string TimeStamp { get; set; }
        [JsonProperty(PropertyName = "sensordatavalues")]
        public List<SensorData> SensorDataValues { get; set; }
    }
};
