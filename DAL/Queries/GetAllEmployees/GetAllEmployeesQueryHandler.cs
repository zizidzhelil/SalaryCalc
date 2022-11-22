using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetAllEmployees
{
	public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IList<Employee>>
	{
		private readonly SalaryCalcContext _context;

		public GetAllEmployeesQueryHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task<IList<Employee>> HandleAsync(GetAllEmployeesQuery query, CancellationToken cancellationToken = default)
		{
			List<Employee> employees = await _context.Employees
			   .ToListAsync(cancellationToken);

			return employees;
		}
	}
}
