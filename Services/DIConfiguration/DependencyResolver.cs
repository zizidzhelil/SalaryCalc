using Core.Commands;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL;
using DAL.Commands.InsertEmployee;
using DAL.Commands.InsertParameter;
using DAL.Commands.UpdateParameter;
using DAL.Queries.GetAllEmployees;
using DAL.Queries.GetAllParameters;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using DAL.Queries.GetEmployeeParameter;
using DAL.Queries.GetYearParams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.ParameterModels.RequestModels;
using Services.Validations;

namespace Services.DIConfiguration
{
	public static class DependencyResolver
	{
		public static IServiceCollection RegisterTypes(
		   this IServiceCollection serviceCollection,
		   IConfiguration configuration)
		{
			// Add database connection string
			serviceCollection.AddDbContext<SalaryCalcContext>(x => x.UseSqlServer(@"Server=localhost;Database=SalaryCalc;Trusted_Connection=True;Encrypt=False"));

			// Queries
			serviceCollection.AddScoped<IQueryHandler<GetAllEmployeesQuery, IList<Employee>>, GetAllEmployeesQueryHandler>();
			serviceCollection.AddScoped<IQueryHandler<GetAllParametersQuery, IList<Parameter>>, GetAllParametersQueryHandler>();
			serviceCollection.AddScoped<IQueryHandler<GetYearParamsQuery, Parameter>, GetYearParamsQueryHandler>();
			serviceCollection.AddScoped<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>, GetEmpAnnualSalaryForYearQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetEmployeeParameterQuery, IList<EmployeeParameter>>, GetEmployeeParameterQueryHandler>();

            // Commands
            serviceCollection.AddScoped<ICommandHandler<InsertEmployeeCommand>, InsertEmployeeCommandHandler>();
			serviceCollection.AddScoped<ICommandHandler<InsertParameterCommand>, InsertParameterCommandHandler>();
			serviceCollection.AddScoped<ICommandHandler<UpdateParameterCommand>, UpdateParameterCommandHandler>();

			// Validations
			serviceCollection.AddScoped<IValidation<PutParameterRequestModel>, PutParameterRequestModelValidator>();
			serviceCollection.AddScoped<IValidation<PostParameterRequestModel>, PostParameterRequestModelValidator>();
			serviceCollection.AddScoped<IValidation<PostEmployeeRequestModel>, PostEmployeeRequestModelValidator>();
			serviceCollection.AddScoped<IValidation<CalculateSalaryRequestModel>, CalculateSalaryRequestModelValidator>();
			serviceCollection.AddScoped<IValidation<GetYearParamsRequestModel>, GetYearParamsRequestModelValidator>();

			return serviceCollection;
		}
	}
}
