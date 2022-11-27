using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployee;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Handlers.EmployeeHandlers
{
    public class PostEmployeesHandler : AsyncRequestHandler<PostEmployeeRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<PostEmployeeRequestModel> _validator;
        private readonly ICommandHandler<InsertEmployeeCommand> _insertEmployeeCommandHandler;

        public PostEmployeesHandler(
            ILogger<PostEmployeesHandler> logger,
            IValidation<PostEmployeeRequestModel> validator,
            ICommandHandler<InsertEmployeeCommand> insertEmployeeCommandHandler)
        {
            _logger = logger;
            _validator = validator;
            _insertEmployeeCommandHandler = insertEmployeeCommandHandler;
        }

        protected override async Task Handle(PostEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(PostEmployeesHandler)} and method {nameof(PostEmployeesHandler.Handle)}");
            await _validator.Validate(request, cancellationToken);

            await _insertEmployeeCommandHandler.HandleAsync(new InsertEmployeeCommand(request.ToEmployee()), cancellationToken);
            _logger.LogInformation($"Begin class {nameof(PostEmployeesHandler)} and method {nameof(PostEmployeesHandler.Handle)}");
        }
    }
}
