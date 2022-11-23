using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetEmpAnnualSalaryForYear
{
	public class GetEmpAnnualSalaryForYearQuery : IQuery<EmployeeParameter>
	{
		public GetEmpAnnualSalaryForYearQuery(int year, int employeeId)
		{
			Year = year;
			EmployeeId = employeeId;
		}

		public int Year { get; }

		public int EmployeeId { get; }
	}
}
