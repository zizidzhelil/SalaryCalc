using Core.Commands;
using Core.Validation;
using DAL.Commands.DeleteEmployeeParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeParameterModels.RequestModels;

namespace Services.Handlers.EmployeeParameterHandlers
{
    public class DeleteEmployeeParameterHandler : AsyncRequestHandler<DeleteEmployeeParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<DeleteEmployeeParameterRequestModel> _validator;
        private readonly ICommandHandler<DeleteEmployeeParameterCommand> _commandHandler;

        public DeleteEmployeeParameterHandler(
            ILogger<DeleteEmployeeParameterHandler> logger,
            IValidation<DeleteEmployeeParameterRequestModel> validator,
            ICommandHandler<DeleteEmployeeParameterCommand> commandHandler)
        {
            _logger = logger;
            _validator = validator;
            _commandHandler = commandHandler;
        }

        protected override async Task Handle(DeleteEmployeeParameterRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeParameterHandler)} and method {nameof(DeleteEmployeeParameterHandler.Handle)}");
            await _validator.Validate(request, cancellationToken);
            await _commandHandler.HandleAsync(new DeleteEmployeeParameterCommand(request.EmployeeParameterId));
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeParameterHandler)} and method {nameof(DeleteEmployeeParameterHandler.Handle)}");
        }
    }
}
