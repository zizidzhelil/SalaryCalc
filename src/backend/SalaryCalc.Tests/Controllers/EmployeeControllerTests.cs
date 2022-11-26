using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using SalaryCalc.Controllers;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Tests.Mocks;

namespace SalaryCalc.Tests.Controllers
{
	public class EmployeeControllerTests
	{
		[Test]
		public async Task GetMethodTest()
		{
			var mockLogger = new Mock<ILogger<EmployeeController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeesRequestModel>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.employeesResponse);
			 
			EmployeeController employeeController = new EmployeeController(mockLogger.Object, mockMediator.Object);

			var result = await employeeController.Get();
			List<EmployeesResponseModel> expected = QueryMocks.employeesResponse;

			var actual = result as OkObjectResult;

			Assert.That(actual.StatusCode, Is.EqualTo(200));
			Assert.That(JsonConvert.SerializeObject(actual.Value), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}

		[Test]
		public async Task PostMethodTest()
		{
			var mockLogger = new Mock<ILogger<EmployeeController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<PostEmployeeRequestModel>(), CancellationToken.None));
			EmployeeController employeeController = new EmployeeController(mockLogger.Object, mockMediator.Object);

			var result = await employeeController.Post(QueryMocks.employee);
			var actual = result as NoContentResult;

			mockMediator.Verify(x => x.Send(It.IsAny<PostEmployeeRequestModel>(), CancellationToken.None), Times.Once);
			Assert.That(actual.StatusCode, Is.EqualTo(204));
		}
	}
}
