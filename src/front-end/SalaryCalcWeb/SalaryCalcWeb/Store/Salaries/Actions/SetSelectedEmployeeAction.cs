namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public record SetSelectedEmployeeAction
    {
        public SetSelectedEmployeeAction(int selectedEmployeeId)
        {
            SelectedEmployeeId = selectedEmployeeId;
        }

        public int SelectedEmployeeId { get; set; }
    }
}
