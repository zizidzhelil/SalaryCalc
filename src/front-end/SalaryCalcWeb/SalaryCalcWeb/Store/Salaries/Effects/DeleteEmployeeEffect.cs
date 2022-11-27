using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.DeleteEmployee;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class DeleteEmployeeEffect : Effect<DeleteEmployeeAction>
    {
        private readonly ICommandHandler<DeleteEmployeeCommand> _commandHandler;

        public DeleteEmployeeEffect(ICommandHandler<DeleteEmployeeCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public override async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _commandHandler.HandleAsync(new DeleteEmployeeCommand(action.EmployeeId), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllEmployeesAction());
        }
    }
}
