using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using SalaryCalc.Controllers;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;
using Services.Tests.Mocks;

namespace SalaryCalc.Tests.Controllers
{
	public class SalaryControllerTests
	{
		[Test]
		public async Task GetNetSalaryMethodTest()
		{
			var mockLogger = new Mock<ILogger<SalaryController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<CalculateSalaryRequestModel>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.calculateSalaryResponse);

			SalaryController salaryController = new SalaryController(mockMediator.Object, mockLogger.Object);

			var result = await salaryController.GetNetSalary(1, 2022, 3100);
			CalculateSalaryResponseModel expected = QueryMocks.calculateSalaryResponse;

			var actual = result as OkObjectResult;

			Assert.That(actual.StatusCode, Is.EqualTo(200));
			Assert.That(JsonConvert.SerializeObject(actual.Value), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
