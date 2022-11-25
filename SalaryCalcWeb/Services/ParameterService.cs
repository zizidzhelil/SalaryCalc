namespace SalaryCalcWeb.Services
{
	public class ParameterService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ParameterService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
	}
}
