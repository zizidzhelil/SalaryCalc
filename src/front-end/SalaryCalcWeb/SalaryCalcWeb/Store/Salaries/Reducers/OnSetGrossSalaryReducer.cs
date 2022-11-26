using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetGrossSalaryReducer : Reducer<SalaryState, SetGrossSalarayAction>
    {
        public override SalaryState Reduce(SalaryState state, SetGrossSalarayAction action)
        {
            return state with
            {
                GrossSalary = action.GrossSalary
            };
        }
    }
}
