using Core.Commands;

namespace DAL.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : ICommand
    {
        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
