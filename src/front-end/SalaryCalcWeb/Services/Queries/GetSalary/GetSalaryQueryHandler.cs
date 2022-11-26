using Core;
using Core.Models;
using Core.Queries;
using System.Text.Json;
using System.Web;

namespace Services.Queries.GetSalary
{
    public class GetSalaryQueryHandler : IQueryHandler<GetSalaryQuery, SalaryModel>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetSalaryQueryHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SalaryModel> HandleAsync(GetSalaryQuery query, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            var queryPath = HttpUtility.ParseQueryString(string.Empty);
            queryPath["employeeId"] = query.SalaryRequest.EmployeeId.ToString();
            queryPath["year"] = query.SalaryRequest.Year.ToString();
            queryPath["grossSalary"] = query.SalaryRequest.GrossSalary.ToString();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get, $"{_appSettings.SalaryPath}?{queryPath}");

            var result = await httpClient.SendAsync(httpRequestMessage);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SalaryModel>(content);
            }

            return null;
        }
    }
}
