using Core.Commands;
using DAL.Commands.InsertEmployee;
using MediatR;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Handlers.EmployeeHandlers
{
	public class PostEmployeesHandler : AsyncRequestHandler<PostEmployeeRequestModel>
	{
		private readonly ICommandHandler<InsertEmployeeCommand> _insertEmployeeCommandHandler;

		public PostEmployeesHandler(ICommandHandler<InsertEmployeeCommand> insertEmployeeCommandHandler)
		{
			_insertEmployeeCommandHandler = insertEmployeeCommandHandler;
		}

		protected override async Task Handle(PostEmployeeRequestModel request, CancellationToken cancellationToken)
		{
			await _insertEmployeeCommandHandler.HandleAsync(new InsertEmployeeCommand(request.FirstName, request.MiddleName, request.LastName, request.BirthDate), cancellationToken);
		}
	}
}
