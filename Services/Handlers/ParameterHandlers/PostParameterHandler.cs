using Common.LogResources;
using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
	public class PostParameterHandler : AsyncRequestHandler<PostParameterRequestModel>
	{
		private readonly ICommandHandler<InsertParameterCommand> _insertParameterCommandHandler;
		private readonly IValidation<PostParameterRequestModel> _validator;
		private readonly ILogger _logger;

		public PostParameterHandler(
			ICommandHandler<InsertParameterCommand> insertParameterCommandHandler,
			IValidation<PostParameterRequestModel> validator,
			ILogger<PostParameterHandler> logger)
		{
			_insertParameterCommandHandler = insertParameterCommandHandler;
			_validator = validator;
			_logger = logger;
		}

		protected override async Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(PostParameterRequestModel)));
			await _insertParameterCommandHandler.HandleAsync(new InsertParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(PostParameterRequestModel)));
		}
	}
}
