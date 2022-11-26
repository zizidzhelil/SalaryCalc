using MediatR;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Models.CalculateSalaryModels.RequestModels
{
	public class CalculateSalaryRequestModel : IRequest<CalculateSalaryResponseModel>
	{
		public CalculateSalaryRequestModel(
			int employeeId,
			int year,
			double? grossSalary)
		{
			EmployeeId = employeeId;
			Year = year;

			if(grossSalary != null)
			{
				GrossSalary = (double)grossSalary;
			}
		}

		public int EmployeeId { get; set; }

		public int Year { get; set; }

		public double GrossSalary { get; set; }
	}
}
