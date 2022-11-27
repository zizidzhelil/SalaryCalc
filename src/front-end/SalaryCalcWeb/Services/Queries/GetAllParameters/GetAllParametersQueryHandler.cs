using Core;
using Core.Models;
using Core.Queries;
using System.Text.Json;

namespace Services.Queries.GetAllParameters
{
    public class GetAllParametersQueryHandler : IQueryHandler<GetAllParametersQuery, IList<ParameterModel>>
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetAllParametersQueryHandler(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<ParameterModel>> HandleAsync(GetAllParametersQuery query, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient("SalaryCalc");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _appSettings.ParameterPath);

            var result = await httpClient.SendAsync(httpRequestMessage);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ParameterModel>>(content);
            }

            return new List<ParameterModel>();
        }
    }
}
