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
                Employees = new List<EmployeeModel>()
            };
        }
    }
}