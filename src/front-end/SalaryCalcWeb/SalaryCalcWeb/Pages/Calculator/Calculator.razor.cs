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

        private int selectedEmployeeId;
        public int SelectedEmployeeId
        {
            get
            {
                return selectedEmployeeId;
            }
            set
            {
                selectedEmployeeId = value;
                Dispatcher.Dispatch(new LoadEmployeeParamsAction(value));
            }
        }


        public int SelectedYear { get; set; }

        public double GrossSalary { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }
    }
}
