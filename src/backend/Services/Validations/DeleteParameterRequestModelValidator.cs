using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetYearParams;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Validations
{
    public class DeleteParameterRequestModelValidator : IValidation<DeleteParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetYearParamsQuery, Parameter> _parametersQueryHandler;

        public DeleteParameterRequestModelValidator(
            ILogger<DeleteParameterRequestModelValidator> logger,
            IQueryHandler<GetYearParamsQuery, Parameter> parametersQueryHandler)
        {
            _logger = logger;
            _parametersQueryHandler = parametersQueryHandler;
        }

        public async Task Validate(DeleteParameterRequestModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteParameterRequestModelValidator)} and method {nameof(DeleteParameterRequestModelValidator.Validate)}");

            List<string> errorMessages = new List<string>();

            var parameter = await _parametersQueryHandler.HandleAsync(new GetYearParamsQuery(model.Year));
            if (parameter == null)
            {
                errorMessages.Add($"Parameter with year {model.Year} does not exists");
            }

            _logger.LogInformation($"End class {nameof(DeleteParameterRequestModelValidator)} and method {nameof(DeleteParameterRequestModelValidator.Validate)}");
            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }
        }
    }
}
