using Core;
using Core.Commands;
using Core.Models;
using Core.Queries;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services.Commands.AddEmployee;
using Services.Commands.AddYearParameters;
using Services.Commands.UpdateParameters;
using Services.Queries.GetAllEmployees;
using Services.Queries.GetEmployeeParams;
using Services.Queries.GetParameters;
using Services.Queries.GetSalary;

namespace SalaryCalcWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var http = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            builder.Services.AddScoped(sp => http);

            using var response = await http.GetAsync("appSettings.json");
            using var stream = await response.Content.ReadAsStreamAsync();

            builder.Configuration.AddJsonStream(stream);

            builder.Services.AddScoped<IAppSettings>(provider => new AppSettings(builder.Configuration));
            builder.Services.AddScoped<IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>>, GetAllEmployeesQueryHandler>();
            builder.Services.AddScoped<IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>>, GetEmployeeParamsQueryHandler>();
            builder.Services.AddScoped<IQueryHandler<GetSalaryQuery, SalaryModel>, GetSalaryQueryHandler>();
            builder.Services.AddScoped<IQueryHandler<GetParametersQuery, ParameterModel>, GetParametersQueryHandler>();
            builder.Services.AddScoped<ICommandHandler<UpdateParametersCommand>, UpdateParametersCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AddEmployeeCommand>, AddEmployeeCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AddYearParametersCommand>, AddYearParametersCommandHandler>();

            var url = builder.Configuration.GetSection("SalaryCalcServer")["SalaryCalcServerHost"];
            builder.Services.AddHttpClient("SalaryCalc", httpClient =>
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SalaryCalcWeb");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Access-Control-Allow-Origin", "*");
            });

            builder.Services.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly)
                .UseReduxDevTools());

            await builder.Build().RunAsync();
        }
    }
}