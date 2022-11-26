using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class UpdateParametersAction
    {
        public UpdateParametersAction(ParameterModel parameter)
        {
            Parameter = parameter;
        }

        public ParameterModel Parameter { get; set; }
    }
}
