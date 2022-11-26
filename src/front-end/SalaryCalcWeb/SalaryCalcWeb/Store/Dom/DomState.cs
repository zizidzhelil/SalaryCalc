namespace SalaryCalcWeb.Store.Dom
{
    public record DomState
    {
        public DomState()
        {
            IsLoading = false;
            ErrorMessage = "AAAAAAAAAAAAAAAAAAAAA";
        }

        public bool IsLoading { get; set; }

        public string ErrorMessage { get; set; }
    }
}
