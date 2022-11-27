namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class DeleteEmployeeParameterAction
    {
        public DeleteEmployeeParameterAction(int employeeParameterId)
        {
            EmployeeParameterId = employeeParameterId;
        }

        public int EmployeeParameterId { get; set; }
    }
}
