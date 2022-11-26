using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetSalaryReducer : Reducer<SalaryState, SetSalaryAction>
    {
        public override SalaryState Reduce(SalaryState state, SetSalaryAction action)
        {
            return state with
            {
                Salary = action.Salary
            };
        }
    }
}
