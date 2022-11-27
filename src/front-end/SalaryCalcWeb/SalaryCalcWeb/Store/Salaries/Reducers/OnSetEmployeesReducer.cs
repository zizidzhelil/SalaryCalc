using Core.Models;
using Fluxor;
using SalaryCalcWeb.Store.Salaries.Actions;

namespace SalaryCalcWeb.Store.Salaries.Reducers
{
    public class OnSetEmployeesReducer : Reducer<SalaryState, SetEmployeesAction>
    {
        public override SalaryState Reduce(SalaryState state, SetEmployeesAction action)
        {
            action.Employees.Insert(0, new EmployeeModel()
            {
                BirthDate = DateTime.MinValue,
                FirstName = string.Empty,
                LastName = string.Empty,
                Id = -1
            });

            return state with
            {
                Employees = action.Employees
            };
        }
    }
}
