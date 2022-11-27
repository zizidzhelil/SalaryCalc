using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using SalaryCalc.Controllers;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;
using Services.Tests.Mocks;

namespace SalaryCalc.Tests.Controllers
{
	public class ParameterControllerTests
	{
		[Test]
		public async Task GetMethodTest()
		{
			var mockLogger = new Mock<ILogger<ParameterController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<GetParametersRequestModel>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parametersResponse);

			ParameterController parameterController = new ParameterController(mockLogger.Object, mockMediator.Object);

			var result = await parameterController.Get();
			List<ParametersResponseModel> expected = QueryMocks.parametersResponse;

			var actual = result as OkObjectResult;

			Assert.That(actual.StatusCode, Is.EqualTo(200));
			Assert.That(JsonConvert.SerializeObject(actual.Value), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}

		[Test]
		public async Task PostMethodTest()
		{
			var mockLogger = new Mock<ILogger<ParameterController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<PostParameterRequestModel>(), CancellationToken.None));
			ParameterController parameterController = new ParameterController(mockLogger.Object, mockMediator.Object);

			var result = await parameterController.Post(QueryMocks.postParameter);
			var actual = result as NoContentResult;

			mockMediator.Verify(x => x.Send(It.IsAny<PostParameterRequestModel>(), CancellationToken.None), Times.Once);
			Assert.That(actual.StatusCode, Is.EqualTo(204));
		}

		[Test]
		public async Task DeleteMethodTest()
		{
			var mockLogger = new Mock<ILogger<ParameterController>>();
			var mockMediator = new Mock<IMediator>();

			mockMediator.Setup(x => x.Send(It.IsAny<int>(), CancellationToken.None));
			ParameterController parameterController = new ParameterController(mockLogger.Object, mockMediator.Object);

			var result = await parameterController.Delete(2022);
			var actual = result as NoContentResult;

			Assert.That(actual.StatusCode, Is.EqualTo(204));
		}
	}
}
