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
            _logger.LogInformation($"Begin class {nameof(GetEmployeesHandler)} and method {nameof(GetEmployeesHandler.Handle)}");

            IList<Employee> employees = await _getAllEmployeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);
			IList<EmployeesResponseModel> employeesResponse = employees.Select(e => new EmployeesResponseModel(e)).ToList();

            _logger.LogInformation($"End class {nameof(GetEmployeesHandler)} and method {nameof(GetEmployeesHandler.Handle)}");

            return employeesResponse;
		}
	}
}
