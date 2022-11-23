using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployee;
using MediatR;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Handlers.EmployeeHandlers
{
	public class PostEmployeesHandler : AsyncRequestHandler<PostEmployeeRequestModel>
	{
		private readonly ICommandHandler<InsertEmployeeCommand> _insertEmployeeCommandHandler;
		private readonly IValidation<PostEmployeeRequestModel> _validator;

		public PostEmployeesHandler(
			ICommandHandler<InsertEmployeeCommand> insertEmployeeCommandHandler,
			IValidation<PostEmployeeRequestModel> validator)
		{
			_insertEmployeeCommandHandler = insertEmployeeCommandHandler;
			_validator = validator;
		}

		protected override async Task Handle(PostEmployeeRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);
			await _insertEmployeeCommandHandler.HandleAsync(new InsertEmployeeCommand(request.FirstName, request.MiddleName, request.LastName, request.BirthDate), cancellationToken);
		}
	}
}
