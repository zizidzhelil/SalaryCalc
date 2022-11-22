using Core.Entities;

namespace DAL.Seed
{
	public class EmployeeSeed
	{
		public EmployeeSeed()
		{
			Employees = new List<Employee>() {
				new Employee() { Id = 1, FirstName = "Martin", MiddleName = "Jelev", LastName = "Bozhilov", BirthDate = new DateTime(1989, 12, 11) },
				new Employee() { Id = 2, FirstName = "Ivan", MiddleName = "Stoqnov", LastName = "Ivanov", BirthDate = new DateTime(1990, 6, 3) },
				new Employee() { Id = 3, FirstName = "Bella", MiddleName = "Stancheva", LastName = "Ivanova", BirthDate = new DateTime(1997, 7, 3) },
				new Employee() { Id = 4, FirstName = "Svetla", MiddleName = "Marinova", LastName = "Ilieva", BirthDate = new DateTime(1985, 2, 14) },
				new Employee() { Id = 5, FirstName = "Marin", MiddleName = "Hristov", LastName = "Marinov", BirthDate = new DateTime(1993, 09, 22) },
				new Employee() { Id = 6, FirstName = "Georgi", MiddleName = "Petrov", LastName = "Georgiev", BirthDate = new DateTime(1994, 12, 14) },
				new Employee() { Id = 7, FirstName = "Ekaterina", MiddleName = "Stancheva", LastName = "Kuzmanova", BirthDate = new DateTime(1983, 8, 14) },
				new Employee() { Id = 8, FirstName = "Nikola", MiddleName = "Ivanov", LastName = "Uzunov", BirthDate = new DateTime(1996, 05, 11) },
				new Employee() { Id = 9, FirstName = "Sofia", MiddleName = "Marinova", LastName = "Marinova", BirthDate = new DateTime(1991, 10, 6) },
				new Employee() { Id = 10, FirstName = "Marina", MiddleName = "Ilieva", LastName = "Ilieva", BirthDate = new DateTime(1992, 1, 12) }
			};
		}

		public List<Employee> Employees { get; }
	}
}
