using Core.Models;

namespace SalaryCalcWeb.Store.Salaries
{
    public record SalaryState
    {
        public SalaryState()
        {
        }

        public IList<EmployeeModel> Employees { get; init; }

        public IList<ParameterModel> Parameters { get; init; }

        public IList<EmployeeParameterModel> EmployeeParams { get; init; }

        public IList<EmployeeParameterDisplayModel> EmployeeParametersDisplay { get; init; }

        public SalaryModel Salary { get; init; }
    }
}
