using Core;
using Core.Models;
using Core.Queries;
using System.Text.Json;
using System.Web;

namespace Services.Queries.GetEmployeeParams
{
    public class GetEmployeeParamsQueryHandler : IQueryHandler<GetEmployeeParamsQuery, IList<EmployeeParameterModel>>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetEmployeeParamsQueryHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<EmployeeParameterModel>> HandleAsync(GetEmployeeParamsQuery query, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            var queryPath = HttpUtility.ParseQueryString(string.Empty);
            queryPath["employeeId"] = query.EmployeeId.ToString();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get, $"{_appSettings.EmployeeParameterPath}?{queryPath}");

            var result = await httpClient.SendAsync(httpRequestMessage);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<EmployeeParameterModel>>(content);
            }

            return new List<EmployeeParameterModel>();
        }
    }
}
