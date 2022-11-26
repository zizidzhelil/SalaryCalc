using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnUpdateParametersReducer : Reducer<SalaryState, UpdateParametersAction>
    {
        public override SalaryState Reduce(SalaryState state, UpdateParametersAction action)
        {
            return state with
            {
                Parameter = action.Parameter
            };
        }
    }
}
