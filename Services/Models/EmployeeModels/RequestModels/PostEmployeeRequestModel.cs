using MediatR;

namespace Services.Models.EmployeeModels.RequestModels
{
	public class PostEmployeeRequestModel : IRequest
	{
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
