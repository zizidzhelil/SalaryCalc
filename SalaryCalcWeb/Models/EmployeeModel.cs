using System.ComponentModel.DataAnnotations;

namespace SalaryCalcWeb.Models
{
	public class EmployeeModel
	{
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
