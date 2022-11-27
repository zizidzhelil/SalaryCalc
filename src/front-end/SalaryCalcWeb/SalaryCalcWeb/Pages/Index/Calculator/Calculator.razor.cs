using Core.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Index.Calculator
{
    public partial class Calculator
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        public int SelectedEmployeeId { get; set; }

        private int selectedYear;

        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;

                var selectedEmployee = State.Value.Employees
                    .FirstOrDefault(e => e.Id == SelectedEmployeeId);

                if (selectedEmployee != null &&
                    selectedEmployee.EmployeeParameters != null &&
                    selectedEmployee.EmployeeParameters.Any())
                {
                    var selectedParameter = selectedEmployee.EmployeeParameters.FirstOrDefault(e => e.Parameter.Year == value);
                    if (selectedParameter != null)
                    {
                        AnnualGrossSalary = selectedParameter.AnnualSalary;
                    }
                }
                else
                {
                    AnnualGrossSalary = null;
                }
            }
        }

        public List<ParameterModel> Parameters
        {
            get
            {
                var selectedEmployee = State.Value.Employees.FirstOrDefault(e => e.Id == SelectedEmployeeId);
                if (selectedEmployee != null && selectedEmployee.EmployeeParameters != null)
                {
                    var parameters = selectedEmployee.EmployeeParameters?.Select(e => e.Parameter)?.ToList()
                        ?? new List<ParameterModel>();

                    parameters.Insert(0, new ParameterModel()
                    {
                        Id = -1,
                        HealthAndSocialInsurancePercentage = 0,
                        TotalIncomeTaxPercentage = 0,
                        Year = -1,
                        MaxThreshold = 0,
                        MinThreshold = 0
                    });

                    return parameters;
                }

                return new List<ParameterModel>();
            }
        }

        public double? AnnualGrossSalary { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }

        protected void Calculate()
        {
            Dispatcher.Dispatch(new LoadNetSalaryAction(SelectedEmployeeId, SelectedYear, AnnualGrossSalary.Value));
        }
    }
}