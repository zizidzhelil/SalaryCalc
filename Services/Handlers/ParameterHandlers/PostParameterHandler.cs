using Core.Commands;
using DAL.Commands.InsertParameter;
using MediatR;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
	public class PostParameterHandler : AsyncRequestHandler<PostParameterRequestModel>
	{
		private readonly ICommandHandler<InsertParameterCommand> _insertParameterCommandHandler;

		public PostParameterHandler(ICommandHandler<InsertParameterCommand> insertParameterCommandHandler)
		{
			_insertParameterCommandHandler = insertParameterCommandHandler;
		}

		protected override async Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _insertParameterCommandHandler.HandleAsync(new InsertParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
		}
	}
}
