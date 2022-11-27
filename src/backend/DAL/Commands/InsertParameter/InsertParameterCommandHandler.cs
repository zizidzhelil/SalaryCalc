using Core.Commands;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.InsertParameter
{
    public class InsertParameterCommandHandler : ICommandHandler<InsertParameterCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public InsertParameterCommandHandler(ILogger<InsertParameterCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(InsertParameterCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(InsertParameterCommandHandler)} and method {nameof(InsertParameterCommandHandler.HandleAsync)}");
            await _context.AddAsync(command.Parameter, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"End class {nameof(InsertParameterCommandHandler)} and method {nameof(InsertParameterCommandHandler.HandleAsync)}");
        }
    }
}
