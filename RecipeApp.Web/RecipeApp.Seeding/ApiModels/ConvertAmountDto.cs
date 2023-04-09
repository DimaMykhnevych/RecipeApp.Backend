using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RecipeApp.Seeding.ApiModels
{
    [DataContract]
    internal class ConvertAmountDto
    {
        /// <summary>
        /// Gets or Sets SourceAmount
        /// </summary>
        [DataMember(Name = "sourceAmount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sourceAmount")]
        public double? SourceAmount { get; set; }

        /// <summary>
        /// Gets or Sets SourceUnit
        /// </summary>
        [DataMember(Name = "sourceUnit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sourceUnit")]
        public string SourceUnit { get; set; }

        /// <summary>
        /// Gets or Sets TargetAmount
        /// </summary>
        [DataMember(Name = "targetAmount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "targetAmount")]
        public double? TargetAmount { get; set; }

        /// <summary>
        /// Gets or Sets TargetUnit
        /// </summary>
        [DataMember(Name = "targetUnit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "targetUnit")]
        public string TargetUnit { get; set; }

        /// <summary>
        /// Gets or Sets Answer
        /// </summary>
        [DataMember(Name = "answer", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "answer")]
        public string Answer { get; set; }
    }
}
