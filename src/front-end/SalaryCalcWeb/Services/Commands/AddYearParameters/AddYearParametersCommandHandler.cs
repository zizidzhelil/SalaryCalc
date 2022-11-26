using Core;
using Core.Commands;
using System.Net.Http.Json;

namespace Services.Commands.AddYearParameters
{
    public class AddYearParametersCommandHandler : ICommandHandler<AddYearParametersCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public AddYearParametersCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(AddYearParametersCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post, $"{_appSettings.ParameterPath}");

            await httpClient.PostAsJsonAsync($"{_appSettings.ParameterPath}", command.YearParameters, CancellationToken.None);
        }
    }
}
