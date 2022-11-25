using SalaryCalcWeb.Models;
using System.Text.Json;

namespace SalaryCalcWeb.Services
{
	public class SalaryService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SalaryService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<SalaryModel> GetNetSalary()
		{
			SalaryModel response = new SalaryModel();

			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "Salary");

			var httpClient = _httpClientFactory.CreateClient("Local");
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
				response = JsonSerializer.Deserialize<SalaryModel>(contentStream);
			}

			return response;
		}
	}
}
