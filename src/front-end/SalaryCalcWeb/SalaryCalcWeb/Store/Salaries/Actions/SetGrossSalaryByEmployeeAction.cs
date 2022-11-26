namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetGrossSalaryByEmployeeAction
    {
        public SetGrossSalaryByEmployeeAction(int employeeParamId)
        {
            EmployeeParamId = employeeParamId;
        }

        public int EmployeeParamId { get; }
    }
}
