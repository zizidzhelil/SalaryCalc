using Common.Exceptions;
using Common.LogResources;
using Core.Validation;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Validations
{
    public class PutParameterRequestModelValidator : IValidation<PutParameterRequestModel>
    {
        private readonly ILogger _logger;

        public PutParameterRequestModelValidator(ILogger<PutParameterRequestModelValidator> logger)
        {
            _logger = logger;
        }

        public Task Validate(PutParameterRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.MinThreshold)));
            if (model.MinThreshold <= 0)
            {
                string message = $"{nameof(model.MinThreshold)} can't be negative number";
                _logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.MinThreshold), message));
                errorMessages.Add(message);
            }
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.MinThreshold)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.MaxThreshold)));
            if (model.MaxThreshold < model.MinThreshold)
            {
                string message = $"{nameof(model.MaxThreshold)} must be greater than {nameof(model.MinThreshold)}";
                _logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.MaxThreshold), message));
                errorMessages.Add(message);
            }
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.MaxThreshold)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.TotalIncomeTaxPercentage)));
            if (model.TotalIncomeTaxPercentage < 0)
            {
                string message = $"{nameof(model.TotalIncomeTaxPercentage)} can't be negative number";
                _logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.TotalIncomeTaxPercentage), message));
                errorMessages.Add(message);
            }
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.TotalIncomeTaxPercentage)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.HealthAndSocialInsurancePercentage)));
            if (model.HealthAndSocialInsurancePercentage < 0)
            {
                string message = $"{nameof(model.HealthAndSocialInsurancePercentage)} can't be negative number";
                _logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.HealthAndSocialInsurancePercentage), message));
                errorMessages.Add(message);
            }
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.HealthAndSocialInsurancePercentage)));

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }

            return Task.CompletedTask;
        }
    }
}
