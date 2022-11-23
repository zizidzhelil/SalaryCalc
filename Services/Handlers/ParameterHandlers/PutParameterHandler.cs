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
		private readonly ICommandHandler<UpdateParameterCommand> _commandHandler;
		private readonly IValidation<PutParameterRequestModel> _validator;
		private readonly ILogger _logger;

		public PutParameterHandler(
			ICommandHandler<UpdateParameterCommand> commandHandler,
			IValidation<PutParameterRequestModel> validator,
			ILogger logger)
		{
			_commandHandler = commandHandler;
			_validator = validator;
			_logger = logger;
		}

		protected override async Task Handle(PutParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(PutParameterRequestModel)));
			await _commandHandler.HandleAsync(new UpdateParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(PutParameterRequestModel)));
		}
	}
}
