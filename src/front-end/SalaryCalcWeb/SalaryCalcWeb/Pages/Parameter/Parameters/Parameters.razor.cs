using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries.Actions;
using SalaryCalcWeb.Store.Salaries;

namespace SalaryCalcWeb.Pages.Parameter.Parameters
{
    public partial class Parameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }


        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllParametersAction());

            return base.OnInitializedAsync();
        }
    }
}
