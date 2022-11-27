using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.AddYearParameters;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class AddYearParametersEffect : Effect<AddYearParametersAction>
    {
        private readonly ICommandHandler<AddYearParametersCommand> _addYearParametersmmand;

        public AddYearParametersEffect(ICommandHandler<AddYearParametersCommand> addYearParametersmmand)
        {
            _addYearParametersmmand = addYearParametersmmand;
        }

        public override async Task HandleAsync(AddYearParametersAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _addYearParametersmmand.HandleAsync(new AddYearParametersCommand(action.YearParameters), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllParametersAction());
        }
    }
}
