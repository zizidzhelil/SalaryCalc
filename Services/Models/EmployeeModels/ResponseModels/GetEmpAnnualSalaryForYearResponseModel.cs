using Core.Entities;

namespace Services.Models.EmployeeModels.ResponseModels
{
	public class GetEmpAnnualSalaryForYearResponseModel
	{
		public GetEmpAnnualSalaryForYearResponseModel(EmployeeParameter employeeParameter)
		{
			if(employeeParameter != null)
			{
				Id = employeeParameter.Id;
				EmployeeId = employeeParameter.EmployeeId;
				Year = employeeParameter.Year;
				AnnualSalary = employeeParameter.AnnualSalary;
			}
		}

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Year { get; set; }

        public double AnnualSalary { get; set; }
    }
}
