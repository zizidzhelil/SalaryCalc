using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetEmployeeParamsReducer : Reducer<SalaryState, SetEmployeeParamsAction>
    {
        public override SalaryState Reduce(SalaryState state, SetEmployeeParamsAction action)
        {
            return state with
            {
                EmployeeParams = action.EmployeeParameterModels
            };
        }
    }
}
