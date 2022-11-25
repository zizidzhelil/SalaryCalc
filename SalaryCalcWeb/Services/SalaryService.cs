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

		public async Task<SalaryModel> GetNetSalary(SalaryRequestModel salaryRequestModel)
		{
			SalaryModel response = new SalaryModel();
			var url = $"Salary?employeeId={salaryRequestModel.EmployeeId}&year={salaryRequestModel.Year}&grossSalary={salaryRequestModel.GrossSalary}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _httpClientFactory.CreateClient("Local");
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<SalaryModel>(content);            
            }

			return response;
		}
	}
}
