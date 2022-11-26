using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalaryCalcWeb.Models
{
    public class EmployeeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
