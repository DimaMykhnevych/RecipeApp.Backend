using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class NutritionDto
    {
        /// <summary>
        /// Gets or Sets Nutrients
        /// </summary>
        [DataMember(Name = "nutrients", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "nutrients")]
        public List<NutrientDto> Nutrients { get; set; }
    }
}
