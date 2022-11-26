using Common.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Tests.Mocks;
using Services.Validations;

namespace Services.Tests.Validations
{
	public class PutParameterRequestModelValidatorTests
	{
		[Test]
		public async Task ValidateMethodTest()
		{
			List<string> errorMessages = new List<string>();
			errorMessages.Add($"{nameof(QueryMocks.putParameterRequestModel.MinThreshold)} can't be negative number");
			errorMessages.Add($"{nameof(QueryMocks.putParameterRequestModel.MaxThreshold)} must be greater than {nameof(QueryMocks.putParameterRequestModel.MinThreshold)}");
			errorMessages.Add($"{nameof(QueryMocks.putParameterRequestModel.TotalIncomeTaxPercentage)} can't be negative number");
			errorMessages.Add($"{nameof(QueryMocks.putParameterRequestModel.HealthAndSocialInsurancePercentage)} can't be negative number");

			var mockLogger = new Mock<ILogger<PutParameterRequestModelValidator>>();


			PutParameterRequestModelValidator modelValidator = new PutParameterRequestModelValidator(mockLogger.Object);

			string actual = string.Empty;
			try
			{
				await modelValidator.Validate(QueryMocks.putParameterRequestModel);
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
