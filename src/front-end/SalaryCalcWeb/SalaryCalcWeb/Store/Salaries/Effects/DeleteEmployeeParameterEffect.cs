using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.DeleteEmployeeParameter;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class DeleteEmployeeParameterEffect : Effect<DeleteEmployeeParameterAction>
    {
        private readonly ICommandHandler<DeleteEmployeeParameterCommand> _commandHandler;

        public DeleteEmployeeParameterEffect(ICommandHandler<DeleteEmployeeParameterCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }
        public override async Task HandleAsync(DeleteEmployeeParameterAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _commandHandler.HandleAsync(new DeleteEmployeeParameterCommand(action.EmployeeParameterId), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllEmployeesAction());
        }
    }
}
