using Core.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.EmployeeParameters
{
    public partial class EmployeeParameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        public int EmployeeId { get; set; }

        public int ParameterId { get; set; }

        public double GrossSalary { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());
            Dispatcher.Dispatch(new LoadAllParametersAction());

            return base.OnInitializedAsync();
        }

        protected void Add()
        {
            var employeeParameter = new EmployeeParameterModel()
            {
                EmployeeId = EmployeeId,
                AnnualSalary = GrossSalary,
                ParameterId = ParameterId
            };

            Dispatcher.Dispatch(new AddEmployeeParameterAction(employeeParameter));

            EmployeeId = 0;
            ParameterId = 0;
            GrossSalary = 0;
        }

        protected void Delete(int id)
        {
            Dispatcher.Dispatch(new DeleteEmployeeParameterAction(id));
        }
    }
}
