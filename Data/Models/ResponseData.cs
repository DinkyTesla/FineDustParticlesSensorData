using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FineDustParticlesSensorData
{
    class ResponseData
    {
        [JsonProperty(PropertyName = "timestamp")]
        public string TimeStamp { get; set; }
        [JsonProperty(PropertyName = "sensordatavalues")]
        public List<SensorData> SensorDataValues { get; set; }
    }
};
