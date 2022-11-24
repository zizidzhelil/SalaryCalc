using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployee;
using Microsoft.Extensions.Logging;
using Services.Handlers.EmployeeHandlers;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Tests.ExtendedHandlers
{
	public class PostEmployeesHandlerExposedToTest : PostEmployeesHandler
	{
		public PostEmployeesHandlerExposedToTest(
			ICommandHandler<InsertEmployeeCommand> insertEmployeeCommandHandler,
			IValidation<PostEmployeeRequestModel> validator,
			ILogger<PostEmployeesHandler> logger)
			: base(insertEmployeeCommandHandler, validator, logger)
		{
		}

		public new Task Handle(PostEmployeeRequestModel request, CancellationToken cancellationToken)
		{
			return base.Handle(request, cancellationToken);
		}
	}
}
