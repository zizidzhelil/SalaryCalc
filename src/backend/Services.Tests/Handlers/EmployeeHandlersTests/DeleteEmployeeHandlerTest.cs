using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using DAL.Queries.GetYearParams;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Services.Handlers.EmployeeHandlers;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;
using Services.Tests.Mocks;

namespace Services.Tests.Handlers.EmployeeHandlersTests
{
    public class DeleteEmployeeHandlerTest
    {
        [Test]
        public async Task HandleMethodTest()
        {
            var mockLogger = new Mock<ILogger<DeleteEmployeeHandler>>();
            var mockValidation = new Mock<IValidation<CalculateSalaryRequestModel>>();
            var mockGetEmpAnnualSalaryForYearQuery = new Mock<IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>>();
            var mockGetYearParamsQuery = new Mock<IQueryHandler<GetYearParamsQuery, Parameter>>();

            mockGetYearParamsQuery.Setup(x => x.HandleAsync(It.IsAny<GetYearParamsQuery>(), CancellationToken.None))
                .ReturnsAsync(QueryMocks.parameter);

            DeleteEmployeeHandler handler = new DeleteEmployeeHandler(mockLogger.Object, mockValidation.Object, mockGetYearParamsQuery.Object, mockGetEmpAnnualSalaryForYearQuery.Object);

            var actual = await handler.Handle(new CalculateSalaryRequestModel(1, 2022, 3100), CancellationToken.None);
            var expected = new CalculateSalaryResponseModel(2340, 310, 450);

            Assert.That(JsonConvert.SerializeObject(actual), Is.EqualTo(JsonConvert.SerializeObject(expected)));
        }
    }
}
