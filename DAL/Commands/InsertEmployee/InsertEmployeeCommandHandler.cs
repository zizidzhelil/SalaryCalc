using Core.Commands;
using Core.Entities;

namespace DAL.Commands.InsertEmployee
{
	public class InsertEmployeeCommandHandler : ICommandHandler<InsertEmployeeCommand>
	{
		private readonly SalaryCalcContext _context;

		public InsertEmployeeCommandHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(InsertEmployeeCommand command, CancellationToken cancellationToken = default)
		{
			Employee employee = new Employee()
			{
				FirstName = command.FirstName,
				MiddleName = command.MiddleName,
				LastName = command.LastName,
				BirthDate = command.BirthDate
			};

			await _context.AddAsync(employee, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
