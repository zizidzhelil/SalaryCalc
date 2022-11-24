using Common.LogResources;
using Core.Commands;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.InsertEmployee
{
	public class InsertEmployeeCommandHandler : ICommandHandler<InsertEmployeeCommand>
	{
		private readonly SalaryCalcContext _context;
		private readonly ILogger _logger;

		public InsertEmployeeCommandHandler(SalaryCalcContext context, ILogger<InsertEmployeeCommandHandler> logger)
		{
			_context = context;
			_logger = logger;
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
