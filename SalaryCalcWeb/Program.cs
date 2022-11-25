using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalaryCalcWeb;
using SalaryCalcWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddHttpClient("Local", httpClient =>
{
	httpClient.BaseAddress = new Uri("https://localhost:7139/");
	httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SalaryCalcWeb");
	httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
});

await builder.Build().RunAsync();
