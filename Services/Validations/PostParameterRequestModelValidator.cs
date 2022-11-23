using Common.Exceptions;
using Core.Validation;
using Services.Models.ParameterModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class PostParameterRequestModelValidator : IValidation<PostParameterRequestModel>
	{
		public PostParameterRequestModelValidator()
		{
		}

		public async Task Validate(PostParameterRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			Regex yearRegex = new("[12]\\d{3}");

			if (!yearRegex.IsMatch(model.Year.ToString()))
			{
				string message = $"{nameof(model.Year)} is invalid";
				errorMessages.Add(message);
			}

			if (model.MinThreshold <= 0)
			{
				string message = $"{nameof(model.MinThreshold)} must be greater than 0";
				errorMessages.Add(message);
			}

			if (model.MaxThreshold > model.MinThreshold)
			{
				string message = $"{nameof(model.MaxThreshold)} must be greater than {nameof(model.MinThreshold)}";
				errorMessages.Add(message);
			}

			if (model.TotalIncomeTaxPercentage < 0)
			{
				string message = $"{nameof(model.TotalIncomeTaxPercentage)} can't be negative number";
				errorMessages.Add(message);
			}

			if (model.HealthAndSocialInsurancePercentage < 0)
			{
				string message = $"{nameof(model.HealthAndSocialInsurancePercentage)} can't be negative number";
				errorMessages.Add(message);
			}

			if (errorMessages.Any())
			{
				string message = string.Join(Environment.NewLine, errorMessages);
				throw new NotFoundException(message);
			}
		}
	}
}
