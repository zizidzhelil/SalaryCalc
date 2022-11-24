using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertParameter;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Handlers.ParameterHandlers;
using Services.Models.ParameterModels.RequestModels;
using Services.Tests.ExtendedHandlers;

namespace Services.Tests.Handlers.ParameterHandlersTests
{
	public class PostParameterHandlerTest
	{
		[Test]
		public async Task HandleMethodTest()
		{
			var mockInsertParameterCommand = new Mock<ICommandHandler<InsertParameterCommand>>();
			var mockLogger = new Mock<ILogger<PostParameterHandler>>();
			var mockValidation = new Mock<IValidation<PostParameterRequestModel>>();

			mockInsertParameterCommand.Setup(x => x.HandleAsync(It.IsAny<InsertParameterCommand>(), CancellationToken.None));

			PostParameterHandlerExposedToTest handler = new PostParameterHandlerExposedToTest(mockInsertParameterCommand.Object, mockValidation.Object, mockLogger.Object);

			await handler.Handle(new PostParameterRequestModel(), CancellationToken.None);

			mockInsertParameterCommand.Verify(x => x.HandleAsync(It.IsAny<InsertParameterCommand>(), CancellationToken.None), Times.Once);
		}
	}
}
