using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;

namespace Services.Handlers.StudentHandlers
{
	public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequestModel, IList<EmployeesResponseModel>>
	{
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _getAllEmployeesQueryHandler;

		public GetEmployeesHandler(
            ILogger<GetEmployeesHandler> logger,
            IQueryHandler<GetAllEmployeesQuery, IList<Employee>> getAllStudentsQueryHandler)
		{
            _logger = logger;
            _getAllEmployeesQueryHandler = getAllStudentsQueryHandler;
		}

		public async Task<IList<EmployeesResponseModel>> Handle(GetEmployeesRequestModel request, CancellationToken cancellationToken)
		{
			IList<Employee> employees = await _getAllEmployeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<EmployeesResponseModel>)));
			IList<EmployeesResponseModel> employeesResponse = employees.Select(e => new EmployeesResponseModel(e)).ToList();
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<EmployeesResponseModel>)));

			return employeesResponse;
		}
	}
}
