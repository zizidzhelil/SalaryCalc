using Core.Commands;
using Core.Validation;
using DAL.Commands.UpdateParameter;
using MediatR;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
	public class PutParameterHandler : AsyncRequestHandler<PutParameterRequestModel>
	{
		private readonly ICommandHandler<UpdateParameterCommand> _commandHandler;
		private readonly IValidation<PutParameterRequestModel> _validator;

		public PutParameterHandler(
			ICommandHandler<UpdateParameterCommand> commandHandler,
			IValidation<PutParameterRequestModel> validator)
		{
			_commandHandler = commandHandler;
			_validator = validator;
		}

		protected override async Task Handle(PutParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);
			await _commandHandler.HandleAsync(new UpdateParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
		}
	}
}
