using Core.Commands;
using Core.Validation;
using DAL.Commands.UpdateParameter;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;
using Services.Tests.ExtendedHandlers;

namespace Services.Tests.Handlers.ParameterHandlersTests
{
	public class PutParameterHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockUpdateParameterCommand = new Mock<ICommandHandler<UpdateParameterCommand>>();
			var mockLogger = new Mock<ILogger<PutParameterHandler>>();
			var mockValidation = new Mock<IValidation<PutParameterRequestModel>>();

			mockUpdateParameterCommand.Setup(x => x.HandleAsync(It.IsAny<UpdateParameterCommand>(), CancellationToken.None));

			PutParameterHandlerExposedToTest handler = new PutParameterHandlerExposedToTest(mockUpdateParameterCommand.Object, mockValidation.Object, mockLogger.Object);

			await handler.Handle(new PutParameterRequestModel(), CancellationToken.None);

			mockUpdateParameterCommand.Verify(x => x.HandleAsync(It.IsAny<UpdateParameterCommand>(), CancellationToken.None), Times.Once);
		}
	}
}
