using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class SetEmployeeParameterDisplayAction
    {
        public SetEmployeeParameterDisplayAction(IList<EmployeeParameterDisplayModel> employeeParametersDisplay)
        {
            EmployeeParametersDisplay = employeeParametersDisplay;
        }

        public IList<EmployeeParameterDisplayModel> EmployeeParametersDisplay { get; set; }
    }
}
