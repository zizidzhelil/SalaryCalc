using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;

namespace Services.Handlers.EmployeeHandlers
{
    public class GetEmpAnnualSalaryForYearHandler : IRequestHandler<GetEmpAnnualSalaryForYearRequestModel, GetEmpAnnualSalaryForYearResponseModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> _queryHandler;

        public GetEmpAnnualSalaryForYearHandler(
            ILogger<GetEmpAnnualSalaryForYearHandler> logger,
            IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> queryHandler)
        {
            _logger = logger;
            _queryHandler = queryHandler;
        }

        public async Task<GetEmpAnnualSalaryForYearResponseModel> Handle(GetEmpAnnualSalaryForYearRequestModel request, CancellationToken cancellationToken)
        {
            var responseModel = new GetEmpAnnualSalaryForYearResponseModel();
            EmployeeParameter employeeParameter = await _queryHandler.HandleAsync(new GetEmpAnnualSalaryForYearQuery(request.EmployeeId, request.Year), cancellationToken);

            if (employeeParameter != null)
            {
                _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<GetEmpAnnualSalaryForYearResponseModel>)));
                responseModel = new GetEmpAnnualSalaryForYearResponseModel(employeeParameter);
                _logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<GetEmpAnnualSalaryForYearResponseModel>)));
            }

            return responseModel;
        }
    }
}
