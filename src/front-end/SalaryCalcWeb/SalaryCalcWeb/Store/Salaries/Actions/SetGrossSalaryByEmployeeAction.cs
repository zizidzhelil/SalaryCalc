namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetGrossSalaryByEmployeeAction
    {
        public SetGrossSalaryByEmployeeAction(int employeeId, int year)
        {
            EmployeeId = employeeId;
            Year = year;
        }

        public int EmployeeId { get; }

        public int Year { get; set; }
    }
}
