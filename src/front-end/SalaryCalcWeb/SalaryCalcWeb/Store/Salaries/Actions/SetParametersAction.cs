using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetParametersAction
    {
        public SetParametersAction(ParameterModel parameter)
        {
            Parameter= parameter;
        }

        public ParameterModel Parameter { get; }
    }
}
