using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class InstructionDto
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember(Name = "steps", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "steps")]
        public List<StepDto> Steps { get; set; }
    }
}
