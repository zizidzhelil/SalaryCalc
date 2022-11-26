using Core;
using Core.Commands;
using System.Net.Http.Json;

namespace Services.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public AddEmployeeCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(AddEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post, $"{_appSettings.EmployeePath}");

            await httpClient.PostAsJsonAsync($"{_appSettings.EmployeePath}", command.Employee, CancellationToken.None);
        }
    }
}
