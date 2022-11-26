using SalaryCalcWeb.Models;
using System.Net.Http.Json;
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

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "Employee");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<List<EmployeeModel>>(content);
            }

            return response;
        }

        public async Task<bool> InsertEmployee(EmployeeModel employee)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "Employee");

            var httpClient = _httpClientFactory.CreateClient("Local");
            var httpResponseMessage = await httpClient.PostAsJsonAsync("Employee", employee);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage.IsSuccessStatusCode;
            }

            return false;
        }
    }
}
