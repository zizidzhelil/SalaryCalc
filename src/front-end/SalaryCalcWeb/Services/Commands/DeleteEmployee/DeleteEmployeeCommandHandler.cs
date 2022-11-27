using Core;
using Core.Commands;

namespace Services.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteEmployeeCommandHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task HandleAsync(DeleteEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");
            await httpClient.DeleteAsync($"{_appSettings.EmployeePath}/{command.EmployeeId}", CancellationToken.None);
        }
    }
}
