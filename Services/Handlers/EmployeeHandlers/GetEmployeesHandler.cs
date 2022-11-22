using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using MediatR;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;

namespace Services.Handlers.StudentHandlers
{
	public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequestModel, IList<EmployeesResponseModel>>
	{
		private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _getAllEmployeesQueryHandler;

		public GetEmployeesHandler(IQueryHandler<GetAllEmployeesQuery, IList<Employee>> getAllStudentsQueryHandler)
		{
			_getAllEmployeesQueryHandler = getAllStudentsQueryHandler;
		}

		public async Task<IList<EmployeesResponseModel>> Handle(GetEmployeesRequestModel request, CancellationToken cancellationToken)
		{
			IList<Employee> employees = await _getAllEmployeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);
			IList<EmployeesResponseModel> employeesResponse = employees.Select(e => new EmployeesResponseModel(e)).ToList();

			return employeesResponse;
		}
	}
}
