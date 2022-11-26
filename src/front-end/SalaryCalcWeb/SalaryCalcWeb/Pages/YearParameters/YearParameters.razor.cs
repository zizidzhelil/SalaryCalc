using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries.Actions;
using SalaryCalcWeb.Store.Salaries;

namespace SalaryCalcWeb.Pages.YearParameters
{
    public partial class YearParameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<SalaryState> State { get; set; }

        protected void Add()
        {
            Dispatcher.Dispatch(new AddYearParametersAction(State.Value.Parameter));
        }
    }
}
