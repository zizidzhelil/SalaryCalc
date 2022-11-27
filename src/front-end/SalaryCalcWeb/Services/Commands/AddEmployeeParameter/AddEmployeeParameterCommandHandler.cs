using Core;
using Core.Commands;
using System.Net.Http.Json;

namespace Services.Commands.AddEmployeeParameter
{
    public class AddEmployeeParameterCommandHandler : ICommandHandler<AddEmployeeParameterCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public AddEmployeeParameterCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(AddEmployeeParameterCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post, $"{_appSettings.EmployeeParameterPath}");

            await httpClient.PostAsJsonAsync($"{_appSettings.EmployeeParameterPath}", command.EmployeeParameter, CancellationToken.None);
        }
    }
}
