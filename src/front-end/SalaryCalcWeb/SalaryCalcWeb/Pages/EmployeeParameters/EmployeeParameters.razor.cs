using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;

namespace SalaryCalcWeb.Pages.EmployeeParameters
{
    public partial class EmployeeParameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }
    }
}
