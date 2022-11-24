using Core.Commands;
using Core.Validation;
using DAL.Commands.UpdateParameter;
using Microsoft.Extensions.Logging;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Tests.ExtendedHandlers
{
	public class PutParameterHandlerExposedToTest : PutParameterHandler
	{
		public PutParameterHandlerExposedToTest(
			ICommandHandler<UpdateParameterCommand> commandHandler, 
			IValidation<PutParameterRequestModel> validator, 
			ILogger<PutParameterHandler> logger) 
			: base(commandHandler, validator, logger)
		{
		}

		public new Task Handle(PutParameterRequestModel request, CancellationToken cancellationToken)
		{
			return base.Handle(request, cancellationToken);
		}
	}
}
