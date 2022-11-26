using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSelectedYearReducer : Reducer<SalaryState, SetSelectedYearAction>
    {
        public override SalaryState Reduce(SalaryState state, SetSelectedYearAction action)
        {
            return state with
            {
                SelectedYear = action.SelectedYear
            };
        }
    }
}
