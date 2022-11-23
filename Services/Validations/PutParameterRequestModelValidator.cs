using Common.Exceptions;
using Core.Validation;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Validations
{
	public class PutParameterRequestModelValidator : IValidation<PutParameterRequestModel>
	{
		public PutParameterRequestModelValidator()
		{
		}

		public async Task Validate(PutParameterRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			if(model.MinThreshold <= 0 )
			{
				string message = $"{nameof(model.MinThreshold)} can't be negative number";
				errorMessages.Add(message);
			}

			if(model.MaxThreshold > model.MinThreshold)
			{
				string message = $"{nameof(model.MaxThreshold)} must be greater than {nameof(model.MinThreshold)}";
				errorMessages.Add(message);
			}

			if(model.TotalIncomeTaxPercentage < 0)
			{
				string message = $"{nameof(model.TotalIncomeTaxPercentage)} can't be negative number";
				errorMessages.Add(message);
			}

			if(model.HealthAndSocialInsurancePercentage < 0)
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
