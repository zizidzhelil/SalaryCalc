﻿using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetAllEmployees;
using Services.Queries.GetEmployeeParams;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadAllEmployeesEffect : Effect<LoadAllEmployeesAction>
    {
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> _getAllEmployeesQuery;
        private readonly IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> _getEmployeeParamQuery;

        public LoadAllEmployeesEffect(
            IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>> getAllEmployeesQuery,
            IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>> getEmployeeParamQuery)
        {
            _getAllEmployeesQuery = getAllEmployeesQuery;
            _getEmployeeParamQuery = getEmployeeParamQuery;
        }

        public override async Task HandleAsync(LoadAllEmployeesAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            IList<EmployeeModel> employees = await _getAllEmployeesQuery.HandleAsync(new GetAllEmployeesQuery());
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetEmployeesAction(employees));

            if (employees.Any())
            {
                dispatcher.Dispatch(new SetLoadingAction(true));
                IList<EmployeeParameterModel> employeeParam = await _getEmployeeParamQuery
                    .HandleAsync(new GetEmployeeParamsQuery(employees.First().Id));
                dispatcher.Dispatch(new SetLoadingAction(false));

                dispatcher.Dispatch(new SetEmployeeParamsAction(employeeParam));
                if (employeeParam.Any())
                {
                    dispatcher.Dispatch(new SetGrossSalarayAction(employeeParam.First().AnnualSalary));
                }
                else
                {
                    dispatcher.Dispatch(new SetGrossSalarayAction(0));
                }
            }
        }
    }
}