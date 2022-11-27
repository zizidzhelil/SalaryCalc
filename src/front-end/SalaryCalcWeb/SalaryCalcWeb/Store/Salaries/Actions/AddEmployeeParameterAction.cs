using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class AddEmployeeParameterAction
    {
        public AddEmployeeParameterAction(EmployeeParameterModel employeeParameter)
        {
            EmployeeParameter = employeeParameter;
        }

        public EmployeeParameterModel EmployeeParameter { get; set; }
    }
}
