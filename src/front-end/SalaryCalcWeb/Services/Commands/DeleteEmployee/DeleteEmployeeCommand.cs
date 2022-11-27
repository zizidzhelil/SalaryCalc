using Core.Commands;

namespace Services.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : ICommand
    {
        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; set; }
    }
}
