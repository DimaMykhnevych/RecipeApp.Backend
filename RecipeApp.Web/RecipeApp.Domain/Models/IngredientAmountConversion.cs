using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RecipeApp.Domain.Models
{
    public class IngredientAmountConversion
    {
        [JsonPropertyName("sourceAmount")]
        public double? SourceAmount { get; set; }

        [JsonPropertyName("sourceUnit")]
        public string SourceUnit { get; set; }

        [JsonPropertyName("targetAmount")]
        public double? TargetAmount { get; set; }

        [JsonPropertyName("targetUnit")]
        public string TargetUnit { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }
    }
}
