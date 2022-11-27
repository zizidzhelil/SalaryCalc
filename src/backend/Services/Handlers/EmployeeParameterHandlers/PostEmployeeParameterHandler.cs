using Core.Commands;
using Core.Validation;
using DAL.Commands.InsertEmployeeParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeParameterModels.RequestModels;

namespace Services.Handlers.EmployeeParameterHandlers
{
    public class PostEmployeeParameterHandler : AsyncRequestHandler<PostEmployeeParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<PostEmployeeParameterRequestModel> _validator;
        private readonly ICommandHandler<InsertEmployeeParameterCommand> _insertEmployeeParameterCommandHandler;

        public PostEmployeeParameterHandler(
            ILogger<PostEmployeeParameterHandler> logger,
            IValidation<PostEmployeeParameterRequestModel> validator,
            ICommandHandler<InsertEmployeeParameterCommand> insertEmployeeParameterCommandHandler)
        {
            _logger = logger;
            _validator = validator;
            _insertEmployeeParameterCommandHandler = insertEmployeeParameterCommandHandler;
        }

        protected override async Task Handle(PostEmployeeParameterRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(PostEmployeeParameterHandler)} and method {nameof(PostEmployeeParameterHandler.Handle)}");
            await _validator.Validate(request, cancellationToken);
            await _insertEmployeeParameterCommandHandler.HandleAsync(new InsertEmployeeParameterCommand(request.ToEmployeeParameter()), cancellationToken);
            _logger.LogInformation($"End class {nameof(PostEmployeeParameterHandler)} and method {nameof(PostEmployeeParameterHandler.Handle)}");
        }
    }
}
