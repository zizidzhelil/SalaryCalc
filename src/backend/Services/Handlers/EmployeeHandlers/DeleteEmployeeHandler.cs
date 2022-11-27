using Core.Commands;
using Core.Validation;
using DAL.Commands.DeleteEmployee;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeHandler : AsyncRequestHandler<DeleteEmployeeRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<DeleteEmployeeRequestModel> _validator;
        private readonly ICommandHandler<DeleteEmployeeCommand> _commandHandler;

        public DeleteEmployeeHandler(
            ILogger<DeleteEmployeeHandler> logger,
            IValidation<DeleteEmployeeRequestModel> validator,
            ICommandHandler<DeleteEmployeeCommand> commandHandler)
        {
            _logger = logger;
            _validator = validator;
            _commandHandler = commandHandler;
        }

        protected override async Task Handle(DeleteEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeHandler)} and method {nameof(DeleteEmployeeHandler.Handle)}");

            await _validator.Validate(request, cancellationToken);
            await _commandHandler.HandleAsync(new DeleteEmployeeCommand(request.EmployeeId));

            _logger.LogInformation($"End class {nameof(DeleteEmployeeHandler)} and method {nameof(DeleteEmployeeHandler.Handle)}");
        }
    }
}
