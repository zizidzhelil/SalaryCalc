using Core.Commands;
using Core.Models;

namespace Services.Commands.AddEmployeeParameter
{
    public class AddEmployeeParameterCommand : ICommand
    {
        public AddEmployeeParameterCommand(EmployeeParameterModel employeeParameter)
        {
            EmployeeParameter = employeeParameter;
        }

        public EmployeeParameterModel EmployeeParameter { get; set; }
    }
}
