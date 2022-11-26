using Core;
using Core.Models;
using Core.Queries;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services.Queries.GetAllEmployees;
using Services.Queries.GetEmployeeParams;

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