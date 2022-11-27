using Core.Commands;
using DAL.Commands.DeleteEmployeeParameter;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.InsertEmployeeParameter
{
    public class InsertEmployeeParameterCommandHandler : ICommandHandler<InsertEmployeeParameterCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public InsertEmployeeParameterCommandHandler(ILogger<InsertEmployeeParameterCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(InsertEmployeeParameterCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(InsertEmployeeParameterCommandHandler)} and method {nameof(InsertEmployeeParameterCommandHandler.HandleAsync)}");
            await _context.AddAsync(command.EmployeeParameter, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"End class {nameof(InsertEmployeeParameterCommandHandler)} and method {nameof(InsertEmployeeParameterCommandHandler.HandleAsync)}");
        }
    }
}
