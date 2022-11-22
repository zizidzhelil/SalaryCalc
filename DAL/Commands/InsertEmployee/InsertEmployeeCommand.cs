using Core.Commands;

namespace DAL.Commands.InsertEmployee
{
	public class InsertEmployeeCommand : ICommand
	{
		public InsertEmployeeCommand(
			string firstName,
			string middleName,
			string lastName,
			DateTime birthDate)
		{
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
			BirthDate = birthDate;
		}

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
