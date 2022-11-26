using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetAllParameters
{
	public class GetAllParametersQueryHandler : IQueryHandler<GetAllParametersQuery, IList<Parameter>>
	{
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

		public GetAllParametersQueryHandler(ILogger<GetAllParametersQueryHandler> logger, SalaryCalcContext context)
		{
            _logger = logger;
            _context = context;
		}

		public async Task<IList<Parameter>> HandleAsync(GetAllParametersQuery query, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation(LogEvents.ListingItems, string.Format(LogMessageResources.ListingItems, nameof(Parameter)));
			List<Parameter> parameters = await _context.Parameters.ToListAsync(cancellationToken);
			_logger.LogInformation(LogEvents.ListedItems, string.Format(LogMessageResources.ListedItems, parameters.Count, nameof(Parameter)));

			return parameters;
		}
	}
}
