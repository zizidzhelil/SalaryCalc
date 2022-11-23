using Core.Commands;
using DAL.Commands.UpdateParameter;
using MediatR;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
	public class PutParameterHandler : AsyncRequestHandler<PutParameterRequestModel>
	{
		private readonly ICommandHandler<UpdateParameterCommand> _commandHandler;

		public PutParameterHandler(ICommandHandler<UpdateParameterCommand> commandHandler)
		{
			_commandHandler = commandHandler;
		}

		protected override async Task Handle(PutParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _commandHandler.HandleAsync(new UpdateParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
		}
	}
}
