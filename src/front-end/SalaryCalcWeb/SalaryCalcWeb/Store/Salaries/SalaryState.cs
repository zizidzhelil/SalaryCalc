using Core.Models;

namespace SalaryCalcWeb.Store.Salaries
{
    public record SalaryState
    {
        public SalaryState()
        {
            Employees = new List<EmployeeModel>();
            EmployeeParams = new List<EmployeeParameterModel>();
            GrossSalary = 0;
        }

        public IList<EmployeeModel> Employees { get; init; }

        public IList<EmployeeParameterModel> EmployeeParams { get; init; }

        public double GrossSalary { get; init; }

        public int SelectedEmployeeId { get; init; }

        public int SelectedYear { get; init; }
    }
}
