using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;

namespace SalaryCalcWeb.Pages.Employee
{
    public partial class Employee
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        protected void Add()
        {
            //Dispatcher.Dispatch(new AddEmployeeAction(State.Value.Employee));
        }
    }
}
