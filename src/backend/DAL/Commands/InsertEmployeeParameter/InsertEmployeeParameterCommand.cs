using Core.Commands;
using Core.Entities;

namespace DAL.Commands.InsertEmployeeParameter
{
    public class InsertEmployeeParameterCommand : ICommand
    {
        public InsertEmployeeParameterCommand(EmployeeParameter employeeParameter)
        {
            EmployeeParameter = employeeParameter;
        }

        public EmployeeParameter EmployeeParameter { get; }
    }
}
