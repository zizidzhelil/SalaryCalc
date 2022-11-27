using Core.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.DeleteEmployeeParameter
{
    public class DeleteEmployeeParameterCommandHandler : ICommandHandler<DeleteEmployeeParameterCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public DeleteEmployeeParameterCommandHandler(ILogger<DeleteEmployeeParameterCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(DeleteEmployeeParameterCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeParameterCommandHandler)} and method {nameof(DeleteEmployeeParameterCommandHandler.HandleAsync)}");

            var employeeParameterToDelete = await _context.EmployeeParameter.SingleOrDefaultAsync(e => e.Id == command.EmployeeParameterId);

            _context.EmployeeParameter.Remove(employeeParameterToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"End class {nameof(DeleteEmployeeParameterCommandHandler)} and method {nameof(DeleteEmployeeParameterCommandHandler.HandleAsync)}");
        }
    }
}
