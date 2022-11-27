using Core.Commands;
using Core.Validation;
using DAL.Commands.DeleteParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
    public class DeleteParameterHandler : AsyncRequestHandler<DeleteParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<DeleteParameterRequestModel> _validator;
        private readonly ICommandHandler<DeleteParameterCommand> _commandHandler;

        public DeleteParameterHandler(
            ILogger<DeleteParameterHandler> logger,
            IValidation<DeleteParameterRequestModel> validator,
            ICommandHandler<DeleteParameterCommand> commandHandler)
        {
            _logger = logger;
            _validator = validator;
            _commandHandler = commandHandler;
        }

        protected override async Task Handle(DeleteParameterRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteParameterHandler)} and method {nameof(DeleteParameterHandler.Handle)}");

            await _validator.Validate(request, cancellationToken);
            await _commandHandler.HandleAsync(new DeleteParameterCommand(request.Year));

            _logger.LogInformation($"End class {nameof(DeleteParameterHandler)} and method {nameof(DeleteParameterHandler.Handle)}");
        }
    }
}
