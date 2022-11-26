using Common.LogResources;
using Core.Commands;
using Core.Entities;
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
            _logger.LogInformation(LogEvents.InsertingItem, string.Format(LogMessageResources.InsertingItem, nameof(Employee)));

            Employee employee = new Employee()
            {
                FirstName = command.FirstName,
                MiddleName = command.MiddleName,
                LastName = command.LastName,
                BirthDate = command.BirthDate
            };

            await _context.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LogEvents.InsertedItem, string.Format(LogMessageResources.InsertedItem, nameof(employee)));
        }
    }
}
