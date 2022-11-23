using Core.Entities;
using Core.Queries;

namespace DAL.Commands.CalculateSalary
{
	public class CalculateSalaryQuery : IQuery<SalaryAndTaxes>
	{
		public CalculateSalaryQuery(
			int employeeId,
			int year,
			double grossSalary)
		{
			EmployeeId = employeeId;
			Year = year;
			GrossSalary = grossSalary;
		}

		public int EmployeeId { get; }

		public int Year { get; }

		public double GrossSalary { get; }
	}
}
