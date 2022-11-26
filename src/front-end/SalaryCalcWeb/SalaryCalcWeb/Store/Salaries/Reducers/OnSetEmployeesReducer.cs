using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetEmployeesReducer : Reducer<SalaryState, SetEmployeesAction>
    {
        public override SalaryState Reduce(SalaryState state, SetEmployeesAction action)
        {
            return state with
            {
                Employees = action.Employees
            };
        }
    }
}
