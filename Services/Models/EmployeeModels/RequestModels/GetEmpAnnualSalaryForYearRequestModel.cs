using MediatR;
using Services.Models.EmployeeModels.ResponseModels;

namespace Services.Models.EmployeeModels.RequestModels
{
	public class GetEmpAnnualSalaryForYearRequestModel : IRequest<GetEmpAnnualSalaryForYearResponseModel>
	{
		public GetEmpAnnualSalaryForYearRequestModel(int employeeId, int year)
		{
			EmployeeId = employeeId;
			Year = year;
		}

		public int EmployeeId { get; set; }

		public int Year { get; set; }
	}
}
