namespace Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<EmployeeParameter> Parameters { get; set; }    
    }
}
