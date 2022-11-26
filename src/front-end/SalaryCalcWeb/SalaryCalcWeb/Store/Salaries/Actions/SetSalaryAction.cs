using Core.Models;

namespace SalaryCalcWeb.Store.Salaries.Actions
{
    public class SetSalaryAction
    {
        public SetSalaryAction(SalaryModel salary)
        {
            Salary = salary;
        }

        public SalaryModel Salary { get; set; }
    }
}
