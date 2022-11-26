using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IList<Employee>>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public GetAllEmployeesQueryHandler(ILogger<GetAllEmployeesQueryHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Employee>> HandleAsync(GetAllEmployeesQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogMessageResources.ListingItems, nameof(Employee)));
            List<Employee> employees = await _context.Employees.ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogMessageResources.ListedItems, employees.Count, nameof(employees)));

            return employees;
        }
    }
}
