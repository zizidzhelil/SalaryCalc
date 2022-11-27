namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class DeleteEmployeeAction
    {
        public DeleteEmployeeAction(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; set; }
    }
}
