namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetSelectedYearAction
    {
        public SetSelectedYearAction(int selectedYear)
        {
            SelectedYear = selectedYear;
        }

        public int SelectedYear { get; set; }
    }
}
