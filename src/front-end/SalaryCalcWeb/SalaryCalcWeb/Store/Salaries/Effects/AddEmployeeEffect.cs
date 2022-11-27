using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.AddEmployee;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class AddEmployeeEffect : Effect<AddEmployeeAction>
    {
        private readonly ICommandHandler<AddEmployeeCommand> _addEmployeeCommand;

        public AddEmployeeEffect(ICommandHandler<AddEmployeeCommand> addEmployeeCommand)
        {
            _addEmployeeCommand = addEmployeeCommand;
        }

        public override async Task HandleAsync(AddEmployeeAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _addEmployeeCommand.HandleAsync(new AddEmployeeCommand(action.Employee), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllEmployeesAction());
        }
    }
}
