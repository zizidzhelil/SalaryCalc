using Common.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Tests.Mocks;
using Services.Validations;

namespace Services.Tests.Validations
{
	public class PostEmployeeRequestModelValidatorTests
	{
		[Test]
		public async Task ValidateMethodTest()
		{
			List<string> errorMessages = new List<string>();
			errorMessages.Add($"{nameof(QueryMocks.postEmployeeRequestModel.BirthDate)} is invalid");
			errorMessages.Add($"Invalid {nameof(QueryMocks.postEmployeeRequestModel.MiddleName)} given");

			var mockLogger = new Mock<ILogger<PostEmployeeRequestModelValidator>>();

			PostEmployeeRequestModelValidator modelValidator = new PostEmployeeRequestModelValidator(mockLogger.Object);

			string actual = string.Empty;
			try
			{
				await modelValidator.Validate(QueryMocks.postEmployeeRequestModel, CancellationToken.None);
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
