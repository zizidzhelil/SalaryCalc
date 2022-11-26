using System.Text.Json.Serialization;

namespace Core.Models
{
    public class EmployeeParameterModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("annualSalary")]
        public double AnnualSalary { get; set; }
    }
}
