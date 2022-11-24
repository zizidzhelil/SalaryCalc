using Core.Entities;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Tests.Mocks
{
	public static class QueryMocks
	{
		public static readonly List<Employee> employees = new List<Employee>()
		{
			new Employee() { Id = 1, FirstName = "Martin", MiddleName = "Jelev", LastName = "Bozhilov", BirthDate = new DateTime(1989, 12, 11) },
			new Employee() { Id = 2, FirstName = "Ivan", MiddleName = "Stoqnov", LastName = "Ivanov", BirthDate = new DateTime(1990, 6, 3) },
			new Employee() { Id = 3, FirstName = "Bella", MiddleName = "Stancheva", LastName = "Ivanova", BirthDate = new DateTime(1997, 7, 3) },
			new Employee() { Id = 4, FirstName = "Svetla", MiddleName = "Marinova", LastName = "Ilieva", BirthDate = new DateTime(1985, 2, 14) }
		};

		public static readonly List<Parameter> parameters = new List<Parameter>()
		{
			new Parameter() {Year = 2022, MinThreshold = 1000, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 10},
			new Parameter() {Year = 2021, MinThreshold = 950, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 9},
			new Parameter() {Year = 2020, MinThreshold = 900, MaxThreshold = 2800, HealthAndSocialInsurancePercentage = 13, TotalIncomeTaxPercentage = 9}
		};

		public static readonly Parameter parameter = new Parameter()
		{
			Year = 2022,
			MinThreshold = 1000,
			MaxThreshold = 3000,
			HealthAndSocialInsurancePercentage = 15,
			TotalIncomeTaxPercentage = 10
		};

		public static readonly EmployeeParameter employeeParameter = new EmployeeParameter()
		{
			Id = 1,
			EmployeeId = 1,
			Year = 2022,
			AnnualSalary = 80000
		};
	}
}
