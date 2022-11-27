using Common.Exceptions;
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

        public Task Validate(PostEmployeeRequestModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(PostEmployeeRequestModelValidator)} and method {nameof(PostEmployeeRequestModelValidator.Validate)}");
            List<string> errorMessages = new List<string>();

            if (model.BirthDate.Year < DateTime.Today.AddYears(-80).Year
                || model.BirthDate.Year > DateTime.Today.AddYears(-15).Year)
            {
                string message = $"{nameof(model.BirthDate)} is invalid";
                errorMessages.Add(message);
            }
            
            Regex nameRegex = new("[a-zA-Z]+");
            if (!nameRegex.IsMatch(model.FirstName))
            {
                string message = $"Invalid {nameof(model.FirstName)} given";
                errorMessages.Add(message);
            }
            
            if (!nameRegex.IsMatch(model.MiddleName))
            {
                string message = $"Invalid {nameof(model.MiddleName)} given";
                errorMessages.Add(message);
            }
            
            if (!nameRegex.IsMatch(model.LastName))
            {
                string message = $"Invalid {nameof(model.LastName)} given";
                errorMessages.Add(message);
            }

            _logger.LogInformation($"End class {nameof(PostEmployeeRequestModelValidator)} and method {nameof(PostEmployeeRequestModelValidator.Validate)}");

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }

            return Task.CompletedTask;
        }
    }
}
