using Common.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Tests.Mocks;
using Services.Validations;

namespace Services.Tests.Validations
{
	public class GetYearParamsRequestModelValidatorTests
	{
		[Test]
		public async Task ValidateMethodTest()
		{
			List<string> errorMessages = new List<string>();
			errorMessages.Add($"Year is invalid");

			var mockLogger = new Mock<ILogger<GetYearParamsRequestModelValidator>>();

			GetYearParamsRequestModelValidator modelValidator = new GetYearParamsRequestModelValidator(mockLogger.Object);

			string actual = string.Empty;
			try
			{
				await modelValidator.Validate(QueryMocks.getYearParamsRequestModel, CancellationToken.None);
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
