using Core;
using Core.Commands;

namespace Services.Commands.DeleteParameter
{
    public class DeleteParameterCommandHandler : ICommandHandler<DeleteParameterCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteParameterCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(DeleteParameterCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");
            await httpClient.DeleteAsync($"{_appSettings.ParameterPath}/{command.Year}", CancellationToken.None);
        }
    }
}
