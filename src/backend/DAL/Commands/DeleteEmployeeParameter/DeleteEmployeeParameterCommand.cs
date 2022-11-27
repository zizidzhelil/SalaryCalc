using Core.Commands;

namespace DAL.Commands.DeleteEmployeeParameter
{
    public class DeleteEmployeeParameterCommand : ICommand
    {
        public DeleteEmployeeParameterCommand(int employeeParameter)
        {
            EmployeeParameterId = employeeParameter;
        }

        public int EmployeeParameterId { get; }
    }
}
