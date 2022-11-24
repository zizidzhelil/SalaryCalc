using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetAllParameters
{
	public class GetAllParametersQueryHandler : IQueryHandler<GetAllParametersQuery, IList<Parameter>>
	{
		private readonly SalaryCalcContext _context;
		private readonly ILogger _logger;

		public GetAllParametersQueryHandler(SalaryCalcContext context, ILogger<GetAllParametersQueryHandler> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IList<Parameter>> HandleAsync(GetAllParametersQuery query, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation(LogEvents.ListingItems, string.Format(LogMessageResources.ListingItems, nameof(Parameter)));
			List<Parameter> parameters = await _context.Parameters
			   .ToListAsync(cancellationToken);
			_logger.LogInformation(LogEvents.ListedItems, string.Format(LogMessageResources.ListedItems, parameters.Count, nameof(Parameter)));

			return parameters;
		}
	}
}
