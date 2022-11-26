using Core.Models;

namespace SalaryCalcWeb.Store.Salaries
{
    public record SalaryState
    {
        public SalaryState()
        {
            Employees = new List<EmployeeModel>();
        }

        public IList<EmployeeModel> Employees { get; init; }
    }
}
