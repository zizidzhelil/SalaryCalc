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
            _logger.LogInformation($"Begin class {nameof(GetYearParamsQueryHandler)} and method {nameof(GetYearParamsQueryHandler.HandleAsync)}");
            Parameter parameter = await _context.Parameters.FindAsync(new object[] { query.Year }, cancellationToken: cancellationToken);
            _logger.LogInformation($"End class {nameof(GetYearParamsQueryHandler)} and method {nameof(GetYearParamsQueryHandler.HandleAsync)}");

            return parameter;
		}
	}
}
