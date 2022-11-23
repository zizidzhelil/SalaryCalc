using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertParameter;
using MediatR;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
	public class PostParameterHandler : AsyncRequestHandler<PostParameterRequestModel>
	{
		private readonly ICommandHandler<InsertParameterCommand> _insertParameterCommandHandler;
		private readonly IValidation<PostParameterRequestModel> _validator;

		public PostParameterHandler(
			ICommandHandler<InsertParameterCommand> insertParameterCommandHandler,
			IValidation<PostParameterRequestModel> validator)
		{
			_insertParameterCommandHandler = insertParameterCommandHandler;
			_validator = validator;
		}

		protected override async Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);
			await _insertParameterCommandHandler.HandleAsync(new InsertParameterCommand(request.Year, request.MinThreshold, request.TotalIncomeTaxPercentage, request.HealthAndSocialInsurancePercentage, request.MaxThreshold), cancellationToken);
		}
	}
}
