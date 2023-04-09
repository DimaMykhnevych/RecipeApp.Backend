using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class MetricDto
    {
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets UnitLong
        /// </summary>
        [DataMember(Name = "unitLong", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unitLong")]
        public string UnitLong { get; set; }

        /// <summary>
        /// Gets or Sets UnitShort
        /// </summary>
        [DataMember(Name = "unitShort", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unitShort")]
        public string UnitShort { get; set; }
    }
}
