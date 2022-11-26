namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record LoadEmployeeParamsAction
    {
        public LoadEmployeeParamsAction(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
