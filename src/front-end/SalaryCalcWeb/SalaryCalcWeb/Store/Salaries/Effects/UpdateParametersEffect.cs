using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.UpdateParameters;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class UpdateParametersEffect : Effect<UpdateParametersAction>
    {
        private readonly ICommandHandler<UpdateParametersCommand> _updateParameterCommand;

        public UpdateParametersEffect(ICommandHandler<UpdateParametersCommand> updateParameterCommand)
        {
            _updateParameterCommand = updateParameterCommand;
        }

        public override async Task HandleAsync(UpdateParametersAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _updateParameterCommand.HandleAsync(new UpdateParametersCommand(action.Parameter), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));
        }
    }
}
