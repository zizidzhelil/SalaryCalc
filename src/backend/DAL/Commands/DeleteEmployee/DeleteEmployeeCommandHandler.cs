using Core.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public DeleteEmployeeCommandHandler(ILogger<DeleteEmployeeCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(DeleteEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeCommandHandler)} and method {nameof(DeleteEmployeeCommandHandler.HandleAsync)}");

            var employeeToDelete = await _context.Employees.SingleOrDefaultAsync(e => e.Id == command.EmployeeId);

            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"End class {nameof(DeleteEmployeeCommandHandler)} and method {nameof(DeleteEmployeeCommandHandler.HandleAsync)}");
        }
    }
}
