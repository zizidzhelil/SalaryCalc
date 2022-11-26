﻿using Common.LogResources;
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
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.GettingItem, nameof(EmployeeParameter), query.EmployeeId, query.Year));
            EmployeeParameter result = await _context.EmployeeParameter
                .SingleOrDefaultAsync(x => x.EmployeeId == query.EmployeeId && x.Year == query.Year, cancellationToken);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(EmployeeParameter), query.EmployeeId, query.Year));
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(EmployeeParameter)));
            return result;
        }
    }
}