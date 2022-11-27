using Core.Commands;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Commands.AddEmployeeParameter;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class AddEmployeeParameterEffect : Effect<AddEmployeeParameterAction>
    {
        private readonly ICommandHandler<AddEmployeeParameterCommand> _addEmployeeParameterCommand;

        public AddEmployeeParameterEffect(ICommandHandler<AddEmployeeParameterCommand> addEmployeeParameterCommand)
        {
            _addEmployeeParameterCommand = addEmployeeParameterCommand;
        }

        public override async Task HandleAsync(AddEmployeeParameterAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            await _addEmployeeParameterCommand.HandleAsync(new AddEmployeeParameterCommand(action.EmployeeParameter), CancellationToken.None);
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new LoadAllEmployeesAction());
        }
    }
}
