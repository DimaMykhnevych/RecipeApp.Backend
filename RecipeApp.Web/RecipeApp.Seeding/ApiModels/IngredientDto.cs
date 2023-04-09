using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class IngredientDto
    {
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets Consitency
        /// </summary>
        [DataMember(Name = "consistency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "consistency")]
        public string Consistency { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Measures
        /// </summary>
        [DataMember(Name = "measures", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "measures")]
        public MeasuresDto Measures { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "nutrition", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "nutrition")]
        public NutritionDto Nutrition { get; set; }
    }
}
