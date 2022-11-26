﻿using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Salaries;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Pages.Calculator
{
    public partial class Calculator
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<SalaryState> State { get; set; }

        private int selectedEmployeeId;
        public int SelectedEmployeeId
        {
            get
            {
                return selectedEmployeeId;
            }
            set
            {
                selectedEmployeeId = value;
                Dispatcher.Dispatch(new LoadEmployeeParamsAction(value));
            }
        }

        private int selectedParamsId;
        public int SelectedParamsId
        {
            get
            {
                return selectedParamsId;
            }
            set
            {
                selectedParamsId = value;
                Dispatcher.Dispatch(new SetGrossSalaryByEmployeeAction(value));
            }
        }

        public double GrossSalary
        {
            get
            {
                return State.Value.GrossSalary;
            }
            set
            {
                Dispatcher.Dispatch(new SetGrossSalarayAction(value));
            }
        }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllEmployeesAction());

            return base.OnInitializedAsync();
        }
    }
}