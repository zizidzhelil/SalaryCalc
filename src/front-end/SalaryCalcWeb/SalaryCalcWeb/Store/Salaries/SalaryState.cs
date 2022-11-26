using Core.Models;

namespace SalaryCalcWeb.Store.Salaries
{
    public record SalaryState
    {
        public SalaryState()
        {
            Employees = new List<EmployeeModel>();
            EmployeeParams = new List<EmployeeParameterModel>();
        }

        public IList<EmployeeModel> Employees { get; init; }

        public IList<EmployeeParameterModel> EmployeeParams { get; init; }
    }
}
