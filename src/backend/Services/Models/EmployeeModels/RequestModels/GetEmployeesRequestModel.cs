using MediatR;
using Services.Models.EmployeeModels.ResponseModels;

namespace Services.Models.EmployeeModels.RequestModels
{
	public class GetEmployeesRequestModel : IRequest<IList<EmployeesResponseModel>>
	{
	}
}
