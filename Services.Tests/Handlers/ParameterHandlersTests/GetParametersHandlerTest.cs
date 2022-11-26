using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllParameters;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.ParameterHandlersTests
{
	public class GetParametersHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockGetAllParametersQuery = new Mock<IQueryHandler<GetAllParametersQuery, IList<Parameter>>>();
			var mockLogger = new Mock<ILogger<GetParametersHandler>>();

			mockGetAllParametersQuery.Setup(x => x.HandleAsync(It.IsAny<GetAllParametersQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parameters);

			GetParametersHandler handler = new GetParametersHandler(mockLogger.Object, mockGetAllParametersQuery.Object);

			var actual = await handler.Handle(new GetParametersRequestModel(), CancellationToken.None);
			var expected = QueryMocks.parameters.Select(x => new ParametersResponseModel(x)).ToList();

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
