using Core.Models;
using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetParametersReducer : Reducer<SalaryState, SetAllParametersAction>
    {
        public override SalaryState Reduce(SalaryState state, SetAllParametersAction action)
        {
            return state with
            {
                Parameters = action.Parameters
            };
        }
    }
}
