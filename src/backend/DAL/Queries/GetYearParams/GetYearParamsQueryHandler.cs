using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetYearParams
{
	public class GetYearParamsQueryHandler : IQueryHandler<GetYearParamsQuery, Parameter>
	{
		private readonly ILogger _logger;
		private readonly SalaryCalcContext _context;

		public GetYearParamsQueryHandler(ILogger<GetYearParamsQueryHandler> logger, SalaryCalcContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<Parameter> HandleAsync(GetYearParamsQuery query, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.GettingItem, nameof(Parameter), query.Year));
			Parameter parameter = await _context.Parameters.FindAsync(new object[] { query.Year }, cancellationToken: cancellationToken);

			if (parameter == null)
			{
				_logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(Parameter), query.Year));
			}

			_logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(Parameter)));
			return parameter;
		}
	}
}
