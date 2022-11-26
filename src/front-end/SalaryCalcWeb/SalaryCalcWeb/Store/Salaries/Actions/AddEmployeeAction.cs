using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class AddEmployeeAction
    {
        public AddEmployeeAction(EmployeeModel employee)
        {
            Employee = employee;
        }

        public EmployeeModel Employee { get; set; }
    }
}
