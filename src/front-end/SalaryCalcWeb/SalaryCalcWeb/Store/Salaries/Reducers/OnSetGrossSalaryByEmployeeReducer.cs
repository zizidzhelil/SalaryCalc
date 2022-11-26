using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetGrossSalaryByEmployeeReducer : Reducer<SalaryState, SetGrossSalaryByEmployeeAction>
    {
        public override SalaryState Reduce(SalaryState state, SetGrossSalaryByEmployeeAction action)
        {
            double grossSalary = 0;
            var selectedEmployee = state.EmployeeParams.FirstOrDefault(e => e.Id == action.EmployeeParamId);
            if (selectedEmployee != null)
            {
                grossSalary = selectedEmployee.AnnualSalary;
            }

            return state with
            {
                GrossSalary = grossSalary
            };
        }
    }
}
