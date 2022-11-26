using Core.Entities;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

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

		public static readonly List<EmployeesResponseModel> employeesResponse = new List<EmployeesResponseModel>()
		{
			new EmployeesResponseModel() { Id = 6, FirstName = "Georgi", MiddleName = "Petrov", LastName = "Georgiev", BirthDate = new DateTime(1994, 12, 14) },
			new EmployeesResponseModel() { Id = 7, FirstName = "Ekaterina", MiddleName = "Stancheva", LastName = "Kuzmanova", BirthDate = new DateTime(1983, 8, 14) },
			new EmployeesResponseModel() { Id = 8, FirstName = "Nikola", MiddleName = "Ivanov", LastName = "Uzunov", BirthDate = new DateTime(1996, 05, 11) },
			new EmployeesResponseModel() { Id = 9, FirstName = "Sofia", MiddleName = "Marinova", LastName = "Marinova", BirthDate = new DateTime(1991, 10, 6) },
			new EmployeesResponseModel() { Id = 10, FirstName = "Marina", MiddleName = "Ilieva", LastName = "Ilieva", BirthDate = new DateTime(1992, 1, 12) }
		};

		public static readonly List<ParametersResponseModel> parametersResponse = new List<ParametersResponseModel>()
		{
			new ParametersResponseModel() {Year = 2022, MinThreshold = 1000, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 10},
			new ParametersResponseModel() {Year = 2021, MinThreshold = 950, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 9},
			new ParametersResponseModel() {Year = 2020, MinThreshold = 900, MaxThreshold = 2800, HealthAndSocialInsurancePercentage = 13, TotalIncomeTaxPercentage = 9}
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

		public static readonly PostEmployeeRequestModel employee = new PostEmployeeRequestModel()
		{
			FirstName = "Bella",
			MiddleName = "Stancheva",
			LastName = "Ivanova",
			BirthDate = new DateTime(1997, 7, 3)
		};

		public static readonly CalculateSalaryRequestModel calculateSalaryRequestModel = new CalculateSalaryRequestModel(33, 30659, -3100);

		public static readonly CalculateSalaryResponseModel calculateSalaryResponse = new CalculateSalaryResponseModel(3100, 10, 15);

		public static readonly ParametersResponseModel parameterResponse = new ParametersResponseModel()
		{
			Year = 2021,
			MinThreshold = 950,
			MaxThreshold = 3000,
			HealthAndSocialInsurancePercentage = 15,
			TotalIncomeTaxPercentage = 9
		};

		public static readonly PostParameterRequestModel postParameter = new PostParameterRequestModel()
		{
			Year = 2022,
			MinThreshold = 1000,
			MaxThreshold = 3000,
			HealthAndSocialInsurancePercentage = 15,
			TotalIncomeTaxPercentage = 10
		};

		public static readonly PutParameterRequestModel putParameter = new PutParameterRequestModel()
		{
			Year = 2012,
			MinThreshold = 1000,
			MaxThreshold = 3000,
			HealthAndSocialInsurancePercentage = 15,
			TotalIncomeTaxPercentage = 10
		};

		public static readonly GetYearParamsRequestModel getYearParamsRequestModel = new GetYearParamsRequestModel(30659);

		public static readonly PostEmployeeRequestModel postEmployeeRequestModel = new PostEmployeeRequestModel()
		{
			FirstName = "Number1",
			MiddleName = "",
			LastName = "126A",
			BirthDate = DateTime.Now
		};

		public static readonly PostParameterRequestModel postParameterRequestModel = new PostParameterRequestModel()
		{
			Year = 26598,
			MinThreshold = -12,
			TotalIncomeTaxPercentage = -15,
			HealthAndSocialInsurancePercentage = -10,
			MaxThreshold = -15
		};

		public static readonly PutParameterRequestModel putParameterRequestModel = new PutParameterRequestModel()
		{
			Year = 26598,
			MinThreshold = -12,
			TotalIncomeTaxPercentage = -15,
			HealthAndSocialInsurancePercentage = -10,
			MaxThreshold = -15
		};
	}
}
