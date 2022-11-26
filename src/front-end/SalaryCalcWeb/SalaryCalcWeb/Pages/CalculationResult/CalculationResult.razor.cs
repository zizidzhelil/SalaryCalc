using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;

namespace SalaryCalcWeb.Pages.CalculationResult
{
    public partial class CalculationResult
    {
        [Inject] public IState<SalaryState> State { get; set; }
    }
}
