using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetEmployeeParameterDisplayReducer : Reducer<SalaryState, SetEmployeeParameterDisplayAction>
    {
        public override SalaryState Reduce(SalaryState state, SetEmployeeParameterDisplayAction action)
        {
            return state with
            {
                EmployeeParametersDisplay = action.EmployeeParametersDisplay.OrderBy(x => x.FirstName).ToList()
            };
        }
    }
}
