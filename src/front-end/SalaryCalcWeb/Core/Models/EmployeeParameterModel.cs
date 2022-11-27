using System.Text.Json.Serialization;

namespace Core.Models
{
    public class EmployeeParameterModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("parameterId")]
        public int ParameterId { get; set; }

        [JsonPropertyName("annualSalary")]
        public double AnnualSalary { get; set; }

        [JsonPropertyName("parameters")]
        public ParameterModel Parameter { get; set; }
    }
}
