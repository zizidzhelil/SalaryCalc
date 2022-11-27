using Core.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.DeleteParameter
{
    public class DeleteParameterCommandHandler : ICommandHandler<DeleteParameterCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public DeleteParameterCommandHandler(ILogger<DeleteParameterCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(DeleteParameterCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteParameterCommandHandler)} and method {nameof(DeleteParameterCommandHandler.HandleAsync)}");

            var parameterToDelete = await _context.Parameters.SingleOrDefaultAsync(p => p.Year == command.Year);

            _context.Parameters.Remove(parameterToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Begin class {nameof(DeleteParameterCommandHandler)} and method {nameof(DeleteParameterCommandHandler.HandleAsync)}");
        }
    }
}
