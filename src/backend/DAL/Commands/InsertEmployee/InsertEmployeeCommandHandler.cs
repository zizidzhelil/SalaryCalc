using Core.Commands;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.InsertEmployee
{
    public class InsertEmployeeCommandHandler : ICommandHandler<InsertEmployeeCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public InsertEmployeeCommandHandler(ILogger<InsertEmployeeCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(InsertEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(InsertEmployeeCommandHandler)} and method {nameof(InsertEmployeeCommandHandler.HandleAsync)}");

            await _context.AddAsync(command.Employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"End class {nameof(InsertEmployeeCommandHandler)} and method {nameof(InsertEmployeeCommandHandler.HandleAsync)}");
        }
    }
}
