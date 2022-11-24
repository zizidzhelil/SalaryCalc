using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertParameter;
using Microsoft.Extensions.Logging;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Tests.ExtendedHandlers
{
	public class PostParameterHandlerExposedToTest : PostParameterHandler
	{
		public PostParameterHandlerExposedToTest(
			ICommandHandler<InsertParameterCommand> insertParameterCommandHandler,
			IValidation<PostParameterRequestModel> validator,
			ILogger<PostParameterHandler> logger)
			: base(insertParameterCommandHandler, validator, logger)
		{
		}
		
		public new Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
		{
			return base.Handle(request, cancellationToken);
		}
	}
}
