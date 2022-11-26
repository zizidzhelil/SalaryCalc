using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Index.SalaryParameters
{
    public partial class SalaryParameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<SalaryState> State { get; set; }

        protected void Update()
        {
            Dispatcher.Dispatch(new UpdateParametersAction(State.Value.Parameter));
        }
    }
}
