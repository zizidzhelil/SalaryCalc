using Core.Entities;

namespace Services.Models.EmployeeModels.ResponseModels
{
	public class EmployeesResponseModel
	{
		public EmployeesResponseModel()
		{
		}

		public EmployeesResponseModel(Employee employee)
		{
			if(employee != null)
			{
				Id = employee.Id;
				FirstName = employee.FirstName;
				MiddleName = employee.MiddleName;
				LastName = employee.LastName;
				BirthDate = employee.BirthDate;
			}
		}

		public long Id { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
