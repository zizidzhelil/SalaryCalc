using Core.Models;

namespace SalaryCalcWeb.Store.Salaries
{
    public record SalaryState
    {
        public SalaryState()
        {
        }

        public IList<EmployeeModel> Employees { get; init; }

        public IList<EmployeeParameterModel> EmployeeParams { get; init; }

        public SalaryModel Salary { get; init; }

        public ParameterModel Parameter { get; init; }

        public double GrossSalary { get; init; }

        public int SelectedEmployeeId { get; init; }

        public int SelectedYear { get; init; }
    }
}
