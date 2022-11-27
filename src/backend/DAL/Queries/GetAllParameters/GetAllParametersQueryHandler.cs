using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetAllParameters
{
    public class GetAllParametersQueryHandler : IQueryHandler<GetAllParametersQuery, IList<Parameter>>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public GetAllParametersQueryHandler(ILogger<GetAllEmployeesQueryHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Parameter>> HandleAsync(GetAllParametersQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(GetAllParametersQueryHandler)} and method {nameof(GetAllParametersQueryHandler.HandleAsync)}");
            List<Parameter> parameters = await _context.Parameters.ToListAsync(cancellationToken);
            _logger.LogInformation($"End class {nameof(GetAllParametersQueryHandler)} and method {nameof(GetAllParametersQueryHandler.HandleAsync)}");

            return parameters;
        }
    }
}
