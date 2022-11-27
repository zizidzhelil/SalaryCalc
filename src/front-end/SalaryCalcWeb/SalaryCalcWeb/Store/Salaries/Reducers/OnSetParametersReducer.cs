using Core.Models;
using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetParametersReducer : Reducer<SalaryState, SetAllParametersAction>
    {
        public override SalaryState Reduce(SalaryState state, SetAllParametersAction action)
        {
            action.Parameters.Insert(0, new ParameterModel()
            {
                Id = -1,
                Year = -1,
                MinThreshold = 0,
                MaxThreshold = 0,
                TotalIncomeTaxPercentage = 0,
                HealthAndSocialInsurancePercentage = 0
            });

            return state with
            {
                Parameters = action.Parameters
            };
        }
    }
}
