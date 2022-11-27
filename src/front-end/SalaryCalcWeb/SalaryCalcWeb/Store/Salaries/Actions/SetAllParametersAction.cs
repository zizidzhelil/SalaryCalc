using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class SetAllParametersAction
    {
        public SetAllParametersAction(IList<ParameterModel> parameters)
        {
            Parameters = parameters;
        }

        public IList<ParameterModel> Parameters { get; set; }
    }
}
