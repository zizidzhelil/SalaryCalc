using Core.Commands;
using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.AddEmployee;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class AddEmployeeEffect : Effect<AddEmployeeAction>
    {
        private readonly ICommandHandler<AddEmployeeCommand> _addEmployeeommand;

        public AddEmployeeEffect(ICommandHandler<AddEmployeeCommand> addEmployeeommand)
        {
            _addEmployeeommand = addEmployeeommand;
        }

        public override async Task HandleAsync(AddEmployeeAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _addEmployeeommand.HandleAsync(new AddEmployeeCommand(action.Employee), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllEmployeesAction());
        }
    }
}
