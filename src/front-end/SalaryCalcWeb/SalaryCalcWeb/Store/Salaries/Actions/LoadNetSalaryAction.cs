using Core.Models.RequestModels;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record LoadNetSalaryAction
    {
        public LoadNetSalaryAction(int employeeId, int year, double grossSalary)
        {
            EmployeeId = employeeId;
            Year = year;
            GrossSalary = grossSalary;
        }

        public int EmployeeId { get; set; }

        public int Year { get; set; }

        public double GrossSalary { get; set; }

        public SalaryRequestModel ToSalaryRequestModel()
        {
            return new SalaryRequestModel()
            {
                EmployeeId = EmployeeId,
                Year = Year,
                GrossSalary = GrossSalary
            };
        }
    }
}
