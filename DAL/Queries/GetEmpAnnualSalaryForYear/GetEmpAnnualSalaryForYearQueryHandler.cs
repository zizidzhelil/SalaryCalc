using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetEmpAnnualSalaryForYear
{
	public class GetEmpAnnualSalaryForYearQueryHandler : IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>
	{
		private readonly SalaryCalcContext _context;

		public GetEmpAnnualSalaryForYearQueryHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task<EmployeeParameter> HandleAsync(GetEmpAnnualSalaryForYearQuery query, CancellationToken cancellationToken = default)
		{
			EmployeeParameter result = await _context.EmployeeParameter.SingleOrDefaultAsync(x => x.EmployeeId == query.EmployeeId && x.Year == query.Year);
			return result;
		}
	}
}
