using Common.Exceptions;
using Common.LogResources;
using Core.Validation;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class GetYearParamsRequestModelValidator : IValidation<GetYearParamsRequestModel>
	{
		private readonly ILogger _logger;

		public GetYearParamsRequestModelValidator(ILogger<GetYearParamsRequestModelValidator> logger)
		{
			_logger = logger;
		}

		public Task Validate(GetYearParamsRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.Year)));
			Regex yearRegex = new("[12]\\d{3}");
			if (!yearRegex.IsMatch(model.Year.ToString()))
			{
				string message = $"{nameof(model.Year)} is invalid";
				_logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.Year), message));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.Year)));

			if (errorMessages.Any())
			{
				string message = string.Join(Environment.NewLine, errorMessages);
				throw new NotFoundException(message);
			}

			return Task.CompletedTask;
		}
	}
}
