using SalaryCalcWeb.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;

namespace SalaryCalcWeb.Services
{
	public class ParameterService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ParameterService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

        public async Task<List<ParameterModel>> GetParameters()
        {
            List<ParameterModel> response = new List<ParameterModel>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "Parameter");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<List<ParameterModel>>(content);
            }

            return response;
        }

        public async Task<ParameterModel> GetParameterByYear(int year)
        {
            ParameterModel response = new ParameterModel();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"Parameter/GetByYear?year={year}");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<ParameterModel>(content);
            }

            return response;
        }

        public async Task<List<EmployeeParameterResponseModel>> GetEmployeeParameter(int employeeId)
        {
            List<EmployeeParameterResponseModel> response = new List<EmployeeParameterResponseModel>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"Parameter/GetByEmployeeId?employeeId={employeeId}");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<List<EmployeeParameterResponseModel>>(content);
            }

            return response;
        }

        public async Task<bool> UpdateYearParameters(ParameterModel yearParameters)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "Parameter");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.PutAsJsonAsync("Parameter", yearParameters);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage.IsSuccessStatusCode;
            }

            return false;
        }
    }
}
