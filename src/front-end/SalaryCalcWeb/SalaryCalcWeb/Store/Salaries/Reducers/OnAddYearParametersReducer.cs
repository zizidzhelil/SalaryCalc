using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnAddYearParametersReducer : Reducer<SalaryState, AddYearParametersAction>
    {
        public override SalaryState Reduce(SalaryState state, AddYearParametersAction action)
        {
            return state with
            {
                Parameter = action.YearParameters
            };
        }
    }
}
