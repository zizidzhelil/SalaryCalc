using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using DAL.Queries.GetYearParams;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.CalculateSalaryHandlers;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.CalculateSalaryHandlersTests
{
	public class CalculateSalaryHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockLogger = new Mock<ILogger<CalculateSalaryHandler>>();
			var mockValidation = new Mock<IValidation<CalculateSalaryRequestModel>>();
			var mockGetEmpAnnualSalaryForYearQuery = new Mock<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>>();
			var mockGetYearParamsQuery = new Mock<IQueryHandler<GetYearParamsQuery, Parameter>>();

			mockGetYearParamsQuery.Setup(x => x.HandleAsync(It.IsAny<GetYearParamsQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parameter);

			CalculateSalaryHandler handler = new CalculateSalaryHandler(mockLogger.Object, mockValidation.Object, mockGetYearParamsQuery.Object, mockGetEmpAnnualSalaryForYearQuery.Object);

			var actual = await handler.Handle(new CalculateSalaryRequestModel(1, 2022, 3100), CancellationToken.None);
			var expected = new CalculateSalaryResponseModel(2340, 310, 450);

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}

		[Test]
		public async Task HandleMethodTestWithoutGivenSalary()
		{
			var mockLogger = new Mock<ILogger<CalculateSalaryHandler>>();
			var mockValidation = new Mock<IValidation<CalculateSalaryRequestModel>>();
			var mockGetEmpAnnualSalaryForYearQuery = new Mock<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>>();
			var mockGetYearParamsQuery = new Mock<IQueryHandler<GetYearParamsQuery, Parameter>>();

			mockGetEmpAnnualSalaryForYearQuery.Setup(x => x.HandleAsync(It.IsAny<GetEmpAnnualSalaryForYearQuery>(), CancellationToken.None))
					.ReturnsAsync(QueryMocks.employeeParameter);

			mockGetYearParamsQuery.Setup(x => x.HandleAsync(It.IsAny<GetYearParamsQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parameter);

			CalculateSalaryHandler handler = new CalculateSalaryHandler(mockLogger.Object, mockValidation.Object, mockGetYearParamsQuery.Object, mockGetEmpAnnualSalaryForYearQuery.Object);

			var actual = await handler.Handle(new CalculateSalaryRequestModel(1, 2022, null), CancellationToken.None);
			var expected = new CalculateSalaryResponseModel(71550, 8000, 450);

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}

		[Test]
		public async Task HandleMethodTestWithtLowSalary()
		{
			var mockLogger = new Mock<ILogger<CalculateSalaryHandler>>();
			var mockValidation = new Mock<IValidation<CalculateSalaryRequestModel>>();
			var mockGetEmpAnnualSalaryForYearQuery = new Mock<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>>();
			var mockGetYearParamsQuery = new Mock<IQueryHandler<GetYearParamsQuery, Parameter>>();

			mockGetEmpAnnualSalaryForYearQuery.Setup(x => x.HandleAsync(It.IsAny<GetEmpAnnualSalaryForYearQuery>(), CancellationToken.None))
					.ReturnsAsync(QueryMocks.employeeParameter);

			mockGetYearParamsQuery.Setup(x => x.HandleAsync(It.IsAny<GetYearParamsQuery>(), CancellationToken.None))
				.ReturnsAsync(QueryMocks.parameter);

			CalculateSalaryHandler handler = new CalculateSalaryHandler(mockLogger.Object, mockValidation.Object, mockGetYearParamsQuery.Object, mockGetEmpAnnualSalaryForYearQuery.Object);

			var actual = await handler.Handle(new CalculateSalaryRequestModel(1, 2021, 900), CancellationToken.None);
			var expected = new CalculateSalaryResponseModel(900, 0, 0);

			Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
		}
	}
}
