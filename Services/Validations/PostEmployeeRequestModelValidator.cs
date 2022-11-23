using Common.Exceptions;
using Common.LogResources;
using Core.Validation;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class PostEmployeeRequestModelValidator : IValidation<PostEmployeeRequestModel>
	{
		private readonly ILogger _logger;

		public PostEmployeeRequestModelValidator(ILogger<PostEmployeeRequestModelValidator> logger)
		{
			_logger = logger;
		}

		public async Task Validate(PostEmployeeRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.BirthDate)));
			if (model.BirthDate.Year < DateTime.Today.AddYears(-80).Year 
				|| model.BirthDate.Year > DateTime.Today.AddYears(-15).Year)
			{
				string message = $"{nameof(model.BirthDate)} is invalid";
				_logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.BirthDate)));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.BirthDate)));

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.FirstName)));
			Regex nameRegex = new("[a-zA-Z]+");
			if (!nameRegex.IsMatch(model.FirstName))
			{
				string message = $"Invalid {nameof(model.FirstName)} given";
				_logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.FirstName)));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.FirstName)));

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.MiddleName)));
			if (!nameRegex.IsMatch(model.MiddleName))
			{
				string message = $"Invalid {nameof(model.MiddleName)} given";
				_logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.MiddleName)));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.MiddleName)));

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.LastName)));
			if (!nameRegex.IsMatch(model.LastName))
			{
				string message = $"Invalid {nameof(model.LastName)} given";
				_logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.LastName)));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.LastName)));

			if (errorMessages.Any())
			{
				string message = string.Join(Environment.NewLine, errorMessages);
				throw new NotFoundException(message);
			}
		}
	}
}
