using Core.Models;
using Fluxor;

namespace SalaryCalcWeb.Store.Salaries
{
    public class SalaryStateFeature : Feature<SalaryState>
    {
        public override string GetName() => nameof(SalaryState);

        protected override SalaryState GetInitialState()
        {
            return new SalaryState
            {
                Employees = new List<EmployeeModel>(),
                EmployeeParams = new List<EmployeeParameterModel>(),
                GrossSalary = 0,
                SelectedEmployeeId = 0,
                SelectedYear = 0
            };
        }
    }
}