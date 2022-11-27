using Core.Commands;

namespace Services.Commands.DeleteEmployeeParameter
{
    public class DeleteEmployeeParameterCommand : ICommand
    {
        public DeleteEmployeeParameterCommand(int employeeParameterId)
        {
            EmployeeParameterId = employeeParameterId;
        }

        public int EmployeeParameterId { get; set; }
    }
}
