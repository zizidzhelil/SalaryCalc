namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class DeleteParameterAction
    {
        public DeleteParameterAction(int year)
        {
            Year = year;
        }

        public int Year { get; set; }
    }
}
