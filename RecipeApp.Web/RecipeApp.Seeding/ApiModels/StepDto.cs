using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class StepDto
    {
        [DataMember(Name = "number", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [DataMember(Name = "step", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "step")]
        public string StepDescription { get; set; }
    }
}
