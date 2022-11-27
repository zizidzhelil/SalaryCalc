using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.DeleteParameter;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class DeleteParameterEffect : Effect<DeleteParameterAction>
    {
        private readonly ICommandHandler<DeleteParameterCommand> _commandHandler;

        public DeleteParameterEffect(ICommandHandler<DeleteParameterCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public override async Task HandleAsync(DeleteParameterAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _commandHandler.HandleAsync(new DeleteParameterCommand(action.Year), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllParametersAction());
        }
    }
}
