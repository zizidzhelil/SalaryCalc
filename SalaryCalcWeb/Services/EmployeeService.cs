using Microsoft.Net.Http.Headers;
using SalaryCalcWeb.Models;
using System.Text.Json;

namespace SalaryCalcWeb.Services
{
	public class EmployeeService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public EmployeeService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<List<EmployeeModel>> GetEmployees()
		{
			List<EmployeeModel> response = new List<EmployeeModel>();

			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7139/Employee");

			var httpClient = _httpClientFactory.CreateClient("Local");
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
				response = JsonSerializer.Deserialize<List<EmployeeModel>>(contentStream);
			}

			return response;
		}
	}
}
