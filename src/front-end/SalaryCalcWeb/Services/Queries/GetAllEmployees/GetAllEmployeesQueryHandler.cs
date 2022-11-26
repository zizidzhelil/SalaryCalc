using Core;
using Core.Models;
using Core.Queries;
using System.Text.Json;

namespace Services.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IList<EmployeeModel>>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetAllEmployeesQueryHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<EmployeeModel>> HandleAsync(GetAllEmployeesQuery query, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _appSettings.EmployeePath);

            var result = await httpClient.SendAsync(httpRequestMessage);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<EmployeeModel>>(content);
            }

            return new List<EmployeeModel>();
        }
    }
}
