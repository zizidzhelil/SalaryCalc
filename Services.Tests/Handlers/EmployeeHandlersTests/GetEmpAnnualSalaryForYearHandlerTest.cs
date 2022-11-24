using Core.Entities;
using Core.Queries;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.EmployeeHandlers;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.EmployeeHandlersTests
{
	public class GetEmpAnnualSalaryForYearHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockLogger = new Mock<ILogger<GetEmpAnnualSalaryForYearHandler>>();
			var mockGetEmpAnnualSalaryForYearQuery = new Mock<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>>();

			mockGetEmpAnnualSalaryForYearQuery.Setup(x => x.HandleAsync(It.IsAny<GetEmpAnnualSalaryForYearQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.employeeParameter);

			GetEmpAnnualSalaryForYearHandler handler = new GetEmpAnnualSalaryForYearHandler(mockGetEmpAnnualSalaryForYearQuery.Object, mockLogger.Object);

			var actual = await handler.Handle(new GetEmpAnnualSalaryForYearRequestModel(1, 2022), CancellationToken.None);
			var expected = new GetEmpAnnualSalaryForYearResponseModel(QueryMocks.employeeParameter);

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
