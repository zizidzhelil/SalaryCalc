using Core.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Employee.Employees
{
    public partial class Employees
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Id { get; set; }


        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }

        protected void Add()
        {
            var employee = new EmployeeModel()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                BirthDate = BirthDate
            };

            Dispatcher.Dispatch(new AddEmployeeAction(employee));

            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            BirthDate = new DateTime();
        }

        protected void Delete(int employeeId)
        {
            Dispatcher.Dispatch(new DeleteEmployeeAction(employeeId));
        }
    }
}
