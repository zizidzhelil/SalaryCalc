using System.Text.Json.Serialization;

namespace SalaryCalcWeb.Models
{
	public class SalaryModel
	{
        [JsonPropertyName("netSalary")]
        public double NetSalary { get; set; }

        [JsonPropertyName("taxTotalIncome")]
        public double TaxTotalIncome { get; set; }

        [JsonPropertyName("taxHealthAndSocialInsurance")]
        public double TaxHealthAndSocialInsurance { get; set; }
	}
}
