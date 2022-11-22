using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetAllParameters
{
	public class GetAllParametersQueryHandler : IQueryHandler<GetAllParametersQuery, IList<Parameter>>
	{
		private readonly SalaryCalcContext _context;

		public GetAllParametersQueryHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task<IList<Parameter>> HandleAsync(GetAllParametersQuery query, CancellationToken cancellationToken = default)
		{
			List<Parameter> parameters = await _context.Parameters
			   .ToListAsync(cancellationToken);

			return parameters;
		}
	}
}
