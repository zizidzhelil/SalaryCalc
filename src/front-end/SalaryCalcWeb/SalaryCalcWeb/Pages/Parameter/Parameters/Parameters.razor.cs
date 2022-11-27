using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries.Actions;
using SalaryCalcWeb.Store.Salaries;
using Core.Models;

namespace SalaryCalcWeb.Pages.Parameter.Parameters
{
    public partial class Parameters
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        public int Year { get; set; }
        public double MinThreshold { get; set; }
        public double MaxThreshold { get; set; }
        public double TotalIncomeTaxPercentage { get; set; }
        public double HealthAndSocialInsurancePercentage { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllParametersAction());

            return base.OnInitializedAsync();
        }

        protected void Add()
        {
            var parameter = new ParameterModel()
            {
                Year = Year,
                MinThreshold = MinThreshold,
                MaxThreshold = MaxThreshold,
                TotalIncomeTaxPercentage = TotalIncomeTaxPercentage,
                HealthAndSocialInsurancePercentage = HealthAndSocialInsurancePercentage
            };

            Dispatcher.Dispatch(new AddYearParametersAction(parameter));

            Year = 0;
            MinThreshold = 0;
            MaxThreshold = 0;
            TotalIncomeTaxPercentage = 0;
            HealthAndSocialInsurancePercentage = 0;
        }

        protected void Delete(int year)
        {
            Dispatcher.Dispatch(new DeleteParameterAction(year));
        }
    }
}
