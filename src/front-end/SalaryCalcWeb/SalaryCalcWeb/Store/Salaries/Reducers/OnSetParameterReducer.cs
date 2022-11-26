using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetParameterReducer : Reducer<SalaryState, SetParametersAction>
    {
        public override SalaryState Reduce(SalaryState state, SetParametersAction action)
        {
            return state with
            {
                Parameter = action.Parameter,
            };
        }
    }
}
