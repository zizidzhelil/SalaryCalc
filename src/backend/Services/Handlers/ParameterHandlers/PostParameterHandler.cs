using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Handlers.ParameterHandlers
{
    public class PostParameterHandler : AsyncRequestHandler<PostParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<PostParameterRequestModel> _validator;
        private readonly ICommandHandler<InsertParameterCommand> _insertParameterCommandHandler;

        public PostParameterHandler(
            ILogger<PostParameterHandler> logger,
            IValidation<PostParameterRequestModel> validator,
            ICommandHandler<InsertParameterCommand> insertParameterCommandHandler)
        {
            _logger = logger;
            _validator = validator;
            _insertParameterCommandHandler = insertParameterCommandHandler;
        }

        protected override async Task Handle(PostParameterRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(PostParameterHandler)} and method {nameof(PostParameterHandler.Handle)}");
            await _validator.Validate(request, cancellationToken);

            await _insertParameterCommandHandler.HandleAsync(new InsertParameterCommand(request.ToParameter()), cancellationToken);
            _logger.LogInformation($"End class {nameof(PostParameterHandler)} and method {nameof(PostParameterHandler.Handle)}");
        }
    }
}
