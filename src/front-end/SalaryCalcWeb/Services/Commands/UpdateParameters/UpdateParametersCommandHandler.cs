using Core;
using Core.Commands;
using System.Net.Http.Json;

namespace Services.Commands.UpdateParameters
{
    public class UpdateParametersCommandHandler : ICommandHandler<UpdateParametersCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public UpdateParametersCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(UpdateParametersCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Put, $"{_appSettings.ParameterPath}");

            await httpClient.PutAsJsonAsync($"{_appSettings.ParameterPath}", command.Parameter, CancellationToken.None);
        }
    }
}
