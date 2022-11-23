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
		private readonly IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> _queryHandler;
		private readonly ILogger _logger;

		public GetEmpAnnualSalaryForYearHandler(IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> queryHandler, ILogger logger)
		{
			_queryHandler = queryHandler;
			_logger = logger;
		}

		public async Task<GetEmpAnnualSalaryForYearResponseModel> Handle(GetEmpAnnualSalaryForYearRequestModel request, CancellationToken cancellationToken)
		{
			EmployeeParameter employeeParameter = await _queryHandler.HandleAsync(new GetEmpAnnualSalaryForYearQuery(request.EmployeeId, request.Year), cancellationToken);

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<GetEmpAnnualSalaryForYearResponseModel>)));
			GetEmpAnnualSalaryForYearResponseModel responseModel = new GetEmpAnnualSalaryForYearResponseModel(employeeParameter);
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<GetEmpAnnualSalaryForYearResponseModel>)));

			return responseModel;
		}
	}
}
