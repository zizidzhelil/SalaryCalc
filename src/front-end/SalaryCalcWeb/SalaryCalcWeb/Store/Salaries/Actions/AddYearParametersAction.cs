using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class AddYearParametersAction
    {
        public AddYearParametersAction(ParameterModel yearParameters)
        {
            YearParameters = yearParameters;
        }

        public ParameterModel YearParameters { get; set; }
    }
}
