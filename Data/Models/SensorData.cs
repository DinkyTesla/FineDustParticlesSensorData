using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FineDustParticlesSensorData
{
    class SensorData
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
        [JsonProperty(PropertyName = "value_type")]
        public string ValueType { get; set; }
    }
}
