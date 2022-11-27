using Core.Commands;
using Core.Entities;

namespace DAL.Commands.InsertEmployee
{
    public class InsertEmployeeCommand : ICommand
    {
        public InsertEmployeeCommand(Employee employee)
        {
            Employee = employee;
        }

        public Employee Employee { get; }
    }
}
