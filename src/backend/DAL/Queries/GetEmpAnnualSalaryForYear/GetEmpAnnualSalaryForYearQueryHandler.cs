using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetEmpAnnualSalaryForYear
{
    public class GetEmpAnnualSalaryForYearQueryHandler : IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public GetEmpAnnualSalaryForYearQueryHandler(ILogger<GetEmpAnnualSalaryForYearQueryHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<EmployeeParameter> HandleAsync(GetEmpAnnualSalaryForYearQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(GetEmpAnnualSalaryForYearQueryHandler)} and method {nameof(GetEmpAnnualSalaryForYearQueryHandler.HandleAsync)}");
            EmployeeParameter result = await _context.EmployeeParameter
                .SingleOrDefaultAsync(x => x.EmployeeId == query.EmployeeId && x.Parameter.Year == query.Year, cancellationToken);

            _logger.LogInformation($"End class {nameof(GetEmpAnnualSalaryForYearQueryHandler)} and method {nameof(GetEmpAnnualSalaryForYearQueryHandler.HandleAsync)}");
            return result;
        }
    }
}
