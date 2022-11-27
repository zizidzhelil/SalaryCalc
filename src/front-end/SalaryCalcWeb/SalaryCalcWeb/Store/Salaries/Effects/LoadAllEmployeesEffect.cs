using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetAllEmployees;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadAllEmployeesEffect : Effect<LoadAllEmployeesAction>
    {
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> _getAllEmployeesQuery;

        public LoadAllEmployeesEffect(
            IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> getAllEmployeesQuery)
        {
            _getAllEmployeesQuery = getAllEmployeesQuery;
        }

        public override async Task HandleAsync(LoadAllEmployeesAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            IList<EmployeeModel> employees = await _getAllEmployeesQuery.HandleAsync(new GetAllEmployeesQuery());
            dispatcher.Dispatch(new SetLoadingAction(false));

            List<EmployeeParameterDisplayModel> employeeParameters = new List<EmployeeParameterDisplayModel>();

            foreach (var employee in employees)
            {
                foreach (var param in employee.EmployeeParameters)
                {
                    employeeParameters.Add(new EmployeeParameterDisplayModel()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Year = param.Parameter.Year,
                        AnnualSalary = param.AnnualSalary,
                        EmployeeParameterId = param.Id,
                        EmployeeId = employee.Id
                    });
                }
            }

            dispatcher.Dispatch(new SetEmployeesAction(employees));
            dispatcher.Dispatch(new SetEmployeeParameterDisplayAction(employeeParameters));
        }
    }
}
