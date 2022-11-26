using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetEmployeesAction
    {
        public SetEmployeesAction(IList<EmployeeModel> employees)
        {
            Employees = employees;
        }

        public IList<EmployeeModel> Employees { get; }
    }
}
