using Common.LogResources;
using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployee;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;
using System.Runtime.CompilerServices;

namespace Services.Handlers.EmployeeHandlers
{
	public class PostEmployeesHandler : AsyncRequestHandler<PostEmployeeRequestModel>
	{
		private readonly ICommandHandler<InsertEmployeeCommand> _insertEmployeeCommandHandler;
		private readonly IValidation<PostEmployeeRequestModel> _validator;
		private readonly ILogger _logger;

		public PostEmployeesHandler(
			ICommandHandler<InsertEmployeeCommand> insertEmployeeCommandHandler,
			IValidation<PostEmployeeRequestModel> validator,
			ILogger<PostEmployeesHandler> logger)
		{
			_insertEmployeeCommandHandler = insertEmployeeCommandHandler;
			_validator = validator;
			_logger = logger;
		}

		protected override async Task Handle(PostEmployeeRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(PostEmployeeRequestModel)));
			await _insertEmployeeCommandHandler.HandleAsync(new InsertEmployeeCommand(request.FirstName, request.MiddleName, request.LastName, request.BirthDate), cancellationToken);
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(PostEmployeeRequestModel)));
		}
	}
}
