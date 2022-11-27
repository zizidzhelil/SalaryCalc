using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetAllEmployees;
using Services.Queries.GetEmployeeParams;
using Services.Queries.GetParameters;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadAllEmployeesEffect : Effect<LoadAllEmployeesAction>
    {
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> _getAllEmployeesQuery;
        private readonly IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> _getEmployeeParamQuery;
        private readonly IQueryHandler<GetParametersQuery, ParameterModel> _getParametersQuery;

        public LoadAllEmployeesEffect(
            IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> getAllEmployeesQuery,
            IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> getEmployeeParamQuery,
            IQueryHandler<GetParametersQuery, ParameterModel> getParametersQuery)
        {
            _getAllEmployeesQuery = getAllEmployeesQuery;
            _getEmployeeParamQuery = getEmployeeParamQuery;
            _getParametersQuery = getParametersQuery;
        }

        public override async Task HandleAsync(LoadAllEmployeesAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            IList<EmployeeModel> employees = await _getAllEmployeesQuery.HandleAsync(new GetAllEmployeesQuery());
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetEmployeesAction(employees));
        }
    }
}
