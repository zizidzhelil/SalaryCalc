using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core.Queries;
using Core.Entities;
using Core.Commands;
using DAL.Queries.GetAllEmployees;
using DAL.Commands.InsertEmployee;
using DAL.Commands.InsertParameter;
using DAL.Queries.GetAllParameters;
using DAL.Commands.UpdateParameter;
using DAL.Commands.CalculateSalary;

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
            serviceCollection.AddScoped<IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes>, CalculateSalaryQueryHandler>();

            // Commands
            serviceCollection.AddScoped<ICommandHandler<InsertEmployeeCommand>, InsertEmployeeCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<InsertParameterCommand>, InsertParameterCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<UpdateParameterCommand>, UpdateParameterCommandHandler>();

            return serviceCollection;
        }
    }
}
