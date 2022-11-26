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
        private readonly ILogger _logger;
        private readonly IValidation<PostParameterRequestModel> _validator;
        private readonly ICommandHandler<InsertParameterCommand> _insertParameterCommandHandler;

		public PostParameterHandler(
            ILogger<PostParameterHandler> logger,
            IValidation<PostParameterRequestModel> validator,
            ICommandHandler<InsertParameterCommand> insertParameterCommandHandler)
		{
            _logger = logger;
            _validator = validator;
            _insertParameterCommandHandler = insertParameterCommandHandler;
		}

		protected override async Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request, cancellationToken);

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(PostParameterRequestModel)));
			await _insertParameterCommandHandler.HandleAsync(new InsertParameterCommand(
				request.Year, 
				request.MinThreshold, 
				request.TotalIncomeTaxPercentage, 
				request.HealthAndSocialInsurancePercentage, 
				request.MaxThreshold), cancellationToken);
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(PostParameterRequestModel)));
		}
	}
}
