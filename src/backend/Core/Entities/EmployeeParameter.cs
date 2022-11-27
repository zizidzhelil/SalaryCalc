namespace Core.Entities
{
    public class EmployeeParameter
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int ParameterId { get; set; }

        public double AnnualSalary { get; set; }

        public Employee Employee { get; set; }

        public Parameter Parameter { get; set; }
    }
}
