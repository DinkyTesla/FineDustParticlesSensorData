using Newtonsoft.Json;

namespace FineDustParticlesSensorData.Data.Models
{
    class SensorData 
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "value_type")]
        public string ValueType { get; set; }
    }
}
