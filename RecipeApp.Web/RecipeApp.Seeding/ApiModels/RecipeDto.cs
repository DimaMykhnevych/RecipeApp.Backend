using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class RecipeDto
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or Sets Servings
        /// </summary>
        [DataMember(Name = "servings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "servings")]
        public int? Servings { get; set; }

        /// <summary>
        /// Gets or Sets ReadyInMinutes
        /// </summary>
        [DataMember(Name = "readyInMinutes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "readyInMinutes")]
        public int? ReadyInMinutes { get; set; }

        /// <summary>
        /// Gets or Sets AnalyzedInstructions
        /// </summary>
        [DataMember(Name = "analyzedInstructions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "analyzedInstructions")]
        public List<InstructionDto> AnalyzedInstructions { get; set; }

        /// <summary>
        /// Gets or Sets Vegan
        /// </summary>
        [DataMember(Name = "vegan", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "vegan")]
        public bool? Vegan { get; set; }

        /// <summary>
        /// Gets or Sets VeryHealthy
        /// </summary>
        [DataMember(Name = "veryHealthy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "veryHealthy")]
        public bool? Healthy { get; set; }

        /// <summary>
        /// Gets or Sets ExtendedIngredients
        /// </summary>
        [DataMember(Name = "extendedIngredients", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "extendedIngredients")]
        public List<IngredientDto> ExtendedIngredients { get; set; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "nutrition", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "nutrition")]
        public NutritionDto Nutrition { get; set; }

        /// <summary>
        /// Gets or Sets DishTypes
        /// </summary>
        [DataMember(Name = "dishTypes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "dishTypes")]
        public List<string> DishTypes { get; set; }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
