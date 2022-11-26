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

		public string FirstName { get; }

		public string MiddleName { get; }

		public string LastName { get; }

		public DateTime BirthDate { get; }
	}
}
