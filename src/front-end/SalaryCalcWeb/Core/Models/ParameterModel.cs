using System.Text.Json.Serialization;

namespace Core.Models
{
    public class ParameterModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("minThreshold")]
        public double MinThreshold { get; set; }

        [JsonPropertyName("totalIncomeTaxPercentage")]
        public double TotalIncomeTaxPercentage { get; set; }

        [JsonPropertyName("healthAndSocialInsurancePercentage")]
        public double HealthAndSocialInsurancePercentage { get; set; }

        [JsonPropertyName("maxThreshold")]
        public double MaxThreshold { get; set; }
    }
}
