using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetEmployeeParams;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadEmployeeParamsEffect : Effect<LoadEmployeeParamsAction>
    {
        private readonly IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> _getEmployeeParamsQuery;

        public LoadEmployeeParamsEffect(IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> getEmployeeParamsQuery)
        {
            _getEmployeeParamsQuery = getEmployeeParamsQuery;
        }

        public override async Task HandleAsync(LoadEmployeeParamsAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            IList<EmployeeParameterModel> employeeParams = await _getEmployeeParamsQuery.HandleAsync(new GetEmployeeParamsQuery(action.EmployeeId));
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetEmployeeParamsAction(employeeParams));

            if (employeeParams.Any())
            {
                dispatcher.Dispatch(new SetGrossSalarayAction(employeeParams.First().AnnualSalary));
            }
            else
            {
                dispatcher.Dispatch(new SetGrossSalarayAction(0));
            }
        }
    }
}
