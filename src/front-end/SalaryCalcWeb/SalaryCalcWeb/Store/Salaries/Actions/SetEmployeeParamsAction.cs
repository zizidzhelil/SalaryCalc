using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetEmployeeParamsAction
    {
        public SetEmployeeParamsAction(IList<EmployeeParameterModel> employeeParameterModels)
        {
            EmployeeParameterModels = employeeParameterModels;
        }

        public IList<EmployeeParameterModel> EmployeeParameterModels { get; }
    }
}
