using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Calculator
{
    public partial class Calculator
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        public int SelectedEmployeeId
        {
            get
            {
                return State.Value.SelectedEmployeeId;
            }
            set
            {
                Dispatcher.Dispatch(new SetSelectedEmployeeAction(value));
                Dispatcher.Dispatch(new LoadEmployeeParamsAction(value));
            }
        }

        public int SelectedParamsId
        {
            get
            {
                return State.Value.SelectedYear;
            }
            set
            {
                Dispatcher.Dispatch(new SetSelectedYearAction(value));
                Dispatcher.Dispatch(new SetGrossSalaryByEmployeeAction(SelectedEmployeeId, value));
                Dispatcher.Dispatch(new LoadParameterAction(value));
            }
        }

        public double GrossSalary
        {
            get
            {
                return State.Value.GrossSalary;
            }
            set
            {
                Dispatcher.Dispatch(new SetGrossSalarayAction(value));
            }
        }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }

        protected void Calculate()
        {
            Dispatcher.Dispatch(new LoadNetSalaryAction(SelectedEmployeeId, SelectedParamsId, GrossSalary));
        }
    }
}
