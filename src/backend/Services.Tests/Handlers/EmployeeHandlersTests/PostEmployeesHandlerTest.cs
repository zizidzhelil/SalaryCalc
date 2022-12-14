using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployee;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Handlers.EmployeeHandlers;
using Services.Models.EmployeeModels.RequestModels;
using Services.Tests.ExtendedHandlers;

namespace Services.Tests.Handlers.EmployeeHandlersTests
{
    public class PostEmployeesHandlerTest
    {
        [Test]
        public async Task HandleMethodTest()
        {
            var mockInsertEmployeeCommand = new Mock<ICommandHandler<InsertEmployeeCommand>>();
            var mockLogger = new Mock<ILogger<PostEmployeesHandler>>();
            var mockValidation = new Mock<IValidation<PostEmployeeRequestModel>>();

            mockInsertEmployeeCommand.Setup(x => x.HandleAsync(It.IsAny<InsertEmployeeCommand>(), CancellationToken.None));

            PostEmployeesHandlerExposedToTest handler = new PostEmployeesHandlerExposedToTest(mockLogger.Object, mockValidation.Object, mockInsertEmployeeCommand.Object);

            await handler.Handle(new PostEmployeeRequestModel(), CancellationToken.None);
            mockInsertEmployeeCommand.Verify(x => x.HandleAsync(It.IsAny<InsertEmployeeCommand>(), CancellationToken.None), Times.Once);
        }
    }
}
