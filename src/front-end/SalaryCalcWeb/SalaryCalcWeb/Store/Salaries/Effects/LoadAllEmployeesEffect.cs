using Core.Models;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadAllEmployeesEffect : Effect<LoadAllEmployeesAction>
    {
        public override async Task HandleAsync(LoadAllEmployeesAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));

            await Task.Delay(2000);
            IList<EmployeeModel> model = new List<EmployeeModel>() {
                new EmployeeModel()
                {
                    BirthDate = DateTime.MaxValue,
                    FirstName = "Zineb",
                    MiddleName = "Yakub",
                    LastName = "Hasanova"
                },
                new EmployeeModel()
                {
                    BirthDate = DateTime.MaxValue,
                    FirstName = "aaaaaa",
                    MiddleName = "bbbbb",
                    LastName = "cccc"
                }
             };

            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetEmployeesAction(model));
        }
    }
}
