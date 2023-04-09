using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class MeasuresDto
    {
        /// <summary>
        /// Gets or Sets Metric
        /// </summary>
        [DataMember(Name = "metric", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "metric")]
        public MetricDto Metric { get; set; }

        /// <summary>
        /// Gets or Sets Us
        /// </summary>
        [DataMember(Name = "us", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "us")]
        public MetricDto Us { get; set; }
    }
}
