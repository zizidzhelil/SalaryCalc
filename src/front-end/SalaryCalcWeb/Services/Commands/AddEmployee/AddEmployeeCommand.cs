using Core.Commands;
using Core.Models;

namespace Services.Commands.AddEmployee
{
    public class AddEmployeeCommand : ICommand
    {
        public AddEmployeeCommand(EmployeeModel employee)
        {
            Employee = employee;
        }

        public EmployeeModel Employee { get; set; }
    }
}
