using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Tests.Mocks;
using Services.Validations;

namespace Services.Tests.Validations
{
	public class CalculateSalaryRequestModelValidatorTest
	{
		[Test]
		public async Task ValidateMethodTest()
		{
			List<string> errorMessages = new List<string>();
			errorMessages.Add($"Employee with id {QueryMocks.calculateSalaryRequestModel.EmployeeId} not found");
			errorMessages.Add($"Year is invalid");

			var mockLogger = new Mock<ILogger<CalculateSalaryRequestModelValidator>>();
			var mockGetAllEmployeesQuery = new Mock<IQueryHandler<GetAllEmployeesQuery, IList<Employee>>>();

			mockGetAllEmployeesQuery.Setup(x => x.HandleAsync(It.IsAny<GetAllEmployeesQuery>(), CancellationToken.None))
				.ReturnsAsync(new List<Employee>());

			CalculateSalaryRequestModelValidator modelValidator = new CalculateSalaryRequestModelValidator(
				mockLogger.Object, mockGetAllEmployeesQuery.Object);

			string actual = string.Empty;
			try
			{
				await modelValidator.Validate(QueryMocks.calculateSalaryRequestModel);
			}
			catch (NotFoundException ex)
			{
				actual = ex.Message;
			}

			var expected = string.Join(Environment.NewLine, errorMessages);

			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
