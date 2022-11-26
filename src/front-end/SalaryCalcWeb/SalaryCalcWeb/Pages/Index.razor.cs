using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages
{
    public partial class Index
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }
    }
}
