using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.StudentHandlers;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.EmployeeHandlersTests
{
	public class GetEmployeesHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockGetAllEmployeesQuery = new Mock<IQueryHandler<GetAllEmployeesQuery, IList<Employee>>>();
			var mockLogger = new Mock<ILogger<GetEmployeesHandler>>();

			mockGetAllEmployeesQuery.Setup(x => x.HandleAsync(It.IsAny<GetAllEmployeesQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.employees);

			GetEmployeesHandler handler = new GetEmployeesHandler(mockLogger.Object, mockGetAllEmployeesQuery.Object);

			var actual = await handler.Handle(new GetEmployeesRequestModel(), CancellationToken.None);
			var expected = QueryMocks.employees.Select(e => new EmployeesResponseModel(e)).ToList();

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
