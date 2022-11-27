using Core;
using Core.Commands;

namespace Services.Commands.DeleteEmployeeParameter
{
    public class DeleteEmployeeParameterCommandHandler : ICommandHandler<DeleteEmployeeParameterCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteEmployeeParameterCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(DeleteEmployeeParameterCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");
            await httpClient.DeleteAsync($"{_appSettings.EmployeeParameterPath}/{command.EmployeeParameterId}", CancellationToken.None);
        }
    }
}
