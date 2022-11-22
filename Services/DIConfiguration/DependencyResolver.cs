using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core.Queries;
using Core.Entities;
using DAL.Queries.GetAllEmployees;
using Core.Commands;
using DAL.Commands.InsertEmployee;

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

            // Commands
            serviceCollection.AddScoped<ICommandHandler<InsertEmployeeCommand>, InsertEmployeeCommandHandler>();

            return serviceCollection;
        }
    }
}
