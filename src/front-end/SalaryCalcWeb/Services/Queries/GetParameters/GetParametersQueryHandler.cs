using Core;
using Core.Models;
using Core.Queries;
using System.Text.Json;
using System.Web;

namespace Services.Queries.GetParameters
{
    public class GetParametersQueryHandler : IQueryHandler<GetParametersQuery, ParameterModel>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetParametersQueryHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ParameterModel> HandleAsync(GetParametersQuery query, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");

            var queryPath = HttpUtility.ParseQueryString(string.Empty);
            queryPath["year"] = query.Year.ToString();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get, $"{_appSettings.ParameterByYearPath}?{queryPath}");

            var result = await httpClient.SendAsync(httpRequestMessage);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ParameterModel>(content);
            }

            return new ParameterModel();
        }
    }
}
