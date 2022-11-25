using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetEmployeeParameter
{
    public class GetEmployeeParameterQueryHandler : IQueryHandler<GetEmployeeParameterQuery, IList<EmployeeParameter>>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public GetEmployeeParameterQueryHandler(ILogger<GetEmployeeParameterQueryHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<EmployeeParameter>> HandleAsync(GetEmployeeParameterQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.GettingItem, nameof(EmployeeParameter), query.EmployeeId));
            IList<EmployeeParameter> employeeParameters = await _context.EmployeeParameter.Where(x => x.EmployeeId == query.EmployeeId).ToListAsync();

            if (employeeParameters == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(EmployeeParameter), query.EmployeeId));
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(EmployeeParameter)));
            return employeeParameters;
        }
    }
}
