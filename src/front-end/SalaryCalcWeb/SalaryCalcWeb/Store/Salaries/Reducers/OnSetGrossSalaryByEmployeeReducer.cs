using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetGrossSalaryByEmployeeReducer : Reducer<SalaryState, SetGrossSalaryByEmployeeAction>
    {
        public override SalaryState Reduce(SalaryState state, SetGrossSalaryByEmployeeAction action)
        {
            double grossSalary = 0;
            var selectedEmployeeParam = state.EmployeeParams
                .FirstOrDefault(e => e.EmployeeId == action.EmployeeId && e.Year == action.Year);

            if (selectedEmployeeParam != null)
            {
                grossSalary = selectedEmployeeParam.AnnualSalary;
            }

            return state with
            {
                GrossSalary = grossSalary
            };
        }
    }
}
