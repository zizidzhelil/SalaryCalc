using Common.Exceptions;
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
            _logger.LogInformation($"Begin class {nameof(PutParameterRequestModelValidator)} and method {nameof(PutParameterRequestModelValidator.Validate)}");
            List<string> errorMessages = new List<string>();

            if (model.MinThreshold <= 0)
            {
                string message = $"{nameof(model.MinThreshold)} can't be negative number";
                errorMessages.Add(message);
            }
            
            if (model.MaxThreshold < model.MinThreshold)
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
            _logger.LogInformation($"End class {nameof(PutParameterRequestModelValidator)} and method {nameof(PutParameterRequestModelValidator.Validate)}");

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }

            return Task.CompletedTask;
        }
    }
}
