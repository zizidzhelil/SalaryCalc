using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Index.Calculator
{
    public partial class Calculator
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }

        protected void Calculate()
        {
            //Dispatcher.Dispatch(new LoadNetSalaryAction(SelectedEmployeeId, SelectedParamsId, GrossSalary));
        }
    }
}
