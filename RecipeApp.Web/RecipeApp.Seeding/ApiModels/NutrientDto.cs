using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class NutrientDto
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets PercentOfDailyNeeds
        /// </summary>
        [DataMember(Name = "percentOfDailyNeeds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "percentOfDailyNeeds")]
        public double? PercentOfDailyNeeds { get; set; }
    }
}
