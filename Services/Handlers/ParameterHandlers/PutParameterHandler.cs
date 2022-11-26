using Common.LogResources;
using Core.Commands;
using Core.Validation;
using DAL.Commands.UpdateParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
    public class PutParameterHandler : AsyncRequestHandler<PutParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<PutParameterRequestModel> _validator;
        private readonly ICommandHandler<UpdateParameterCommand> _commandHandler;

        public PutParameterHandler(
            ILogger<PutParameterHandler> logger,
            IValidation<PutParameterRequestModel> validator,
            ICommandHandler<UpdateParameterCommand> commandHandler)
        {
            _logger = logger;
            _validator = validator;
            _commandHandler = commandHandler;
        }

        protected override async Task Handle(PutParameterRequestModel request, CancellationToken cancellationToken)
        {
            await _validator.Validate(request, cancellationToken);

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(PutParameterRequestModel)));
            await _commandHandler.HandleAsync(new UpdateParameterCommand(
                request.Year,
                request.MinThreshold,
                request.TotalIncomeTaxPercentage,
                request.HealthAndSocialInsurancePercentage,
                request.MaxThreshold), cancellationToken);
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(PutParameterRequestModel)));
        }
    }
}
