using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnAddEmployeeReducer : Reducer<SalaryState, AddEmployeeAction>
    {
        public override SalaryState Reduce(SalaryState state, AddEmployeeAction action)
        {
            return state with
            {
                Employee = action.Employee
            };
        }
    }
}
