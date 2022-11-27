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
            _logger.LogInformation($"Begin class {nameof(GetAllEmployeesQueryHandler)} and method {nameof(GetAllEmployeesQueryHandler.HandleAsync)}");
            List<Employee> employees = await _context.Employees
                .Include(e => e.Parameters)
                .ThenInclude(e => e.Parameter)
                .ToListAsync(cancellationToken);
            _logger.LogInformation($"End class {nameof(GetAllEmployeesQueryHandler)} and method {nameof(GetAllEmployeesQueryHandler.HandleAsync)}");

            return employees;
        }
    }
}
