using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetYearParams;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.ParameterHandlersTests
{
	public class GetYearParamsHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockLogger = new Mock<ILogger<GetYearParamsHandler>>();
			var mockValidation = new Mock<IValidation<GetYearParamsRequestModel>>();
			var mockGetYearParamsQuery = new Mock<IQueryHandler<GetYearParamsQuery, Parameter>>();

			mockGetYearParamsQuery.Setup(x => x.HandleAsync(It.IsAny<GetYearParamsQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parameter);

			GetYearParamsHandler handler = new GetYearParamsHandler(mockLogger.Object, mockValidation.Object, mockGetYearParamsQuery.Object);

			var actual = await handler.Handle(new GetYearParamsRequestModel(2022), CancellationToken.None);
			var expected = new ParametersResponseModel(QueryMocks.parameter);
			
			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
