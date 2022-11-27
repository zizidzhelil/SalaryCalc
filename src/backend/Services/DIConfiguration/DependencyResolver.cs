using Core.Commands;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL;
using DAL.Commands.DeleteEmployee;
using DAL.Commands.DeleteEmployeeParameter;
using DAL.Commands.DeleteParameter;
using DAL.Commands.InsertEmployee;
using DAL.Commands.InsertEmployeeParameter;
using DAL.Commands.InsertParameter;
using DAL.Commands.UpdateParameter;
using DAL.Queries.GetAllEmployees;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using DAL.Queries.GetYearParams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeParameterModels.RequestModels;
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
			serviceCollection.AddDbContext<SalaryCalcContext>(x => x.UseSqlServer(configuration.GetConnectionString("SalaryCalc")));

			// Queries
			serviceCollection.AddScoped<IQueryHandler<GetAllEmployeesQuery, IList<Employee>>, GetAllEmployeesQueryHandler>();
			serviceCollection.AddScoped<IQueryHandler<GetYearParamsQuery, Parameter>, GetYearParamsQueryHandler>();
			serviceCollection.AddScoped<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>, GetEmpAnnualSalaryForYearQueryHandler>();

            // Commands
            serviceCollection.AddScoped<ICommandHandler<DeleteEmployeeCommand>, DeleteEmployeeCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeleteEmployeeParameterCommand>, DeleteEmployeeParameterCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeleteParameterCommand>, DeleteParameterCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<InsertEmployeeCommand>, InsertEmployeeCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<InsertEmployeeParameterCommand>, InsertEmployeeParameterCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<InsertParameterCommand>, InsertParameterCommandHandler>();
			serviceCollection.AddScoped<ICommandHandler<UpdateParameterCommand>, UpdateParameterCommandHandler>();

            // Validations
            serviceCollection.AddScoped<IValidation<CalculateSalaryRequestModel>, CalculateSalaryRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<DeleteEmployeeParameterRequestModel>, DeleteEmployeeParameterRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<DeleteEmployeeRequestModel>, DeleteEmployeeRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<DeleteParameterRequestModel>, DeleteParameterRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<PostEmployeeParameterRequestModel>, PostEmployeeParameterRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<PostEmployeeRequestModel>, PostEmployeeRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<PostParameterRequestModel>, PostParameterRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<PutParameterRequestModel>, PutParameterRequestModelValidator>();

			return serviceCollection;
		}
	}
}
