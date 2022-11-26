using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSelectedEmployeeReducer : Reducer<SalaryState, SetSelectedEmployeeAction>
    {
        public override SalaryState Reduce(SalaryState state, SetSelectedEmployeeAction action)
        {
            return state with
            {
                SelectedEmployeeId = action.SelectedEmployeeId
            };
        }
    }
}
