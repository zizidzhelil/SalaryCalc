namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetGrossSalarayAction
    {
        public SetGrossSalarayAction(double grossSalary)
        {
            GrossSalary = grossSalary;
        }

        public double GrossSalary { get; set; }
    }
}
