using Common.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Tests.Mocks;
using Services.Validations;

namespace Services.Tests.Validations
{
	public class PostParameterRequestModelValidatorTests
	{
		[Test]
		public async Task ValidateMethodTest()
		{
			List<string> errorMessages = new List<string>();
			errorMessages.Add($"MinThreshold must be greater than 0");
			errorMessages.Add($"TotalIncomeTaxPercentage can't be negative number");
			errorMessages.Add($"HealthAndSocialInsurancePercentage can't be negative number");

			var mockLogger = new Mock<ILogger<PostParameterRequestModelValidator>>();


			PostParameterRequestModelValidator modelValidator = new PostParameterRequestModelValidator(mockLogger.Object);

			string actual = string.Empty;
			try
			{
				await modelValidator.Validate(QueryMocks.postParameterRequestModel);
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
