namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record LoadParameterAction
    {
        public LoadParameterAction(int year)
        {
            Year= year;
        }

        public int Year { get; set; }
    }
}
