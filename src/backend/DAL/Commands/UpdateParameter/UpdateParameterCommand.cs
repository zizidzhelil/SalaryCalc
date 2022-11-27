using Core.Commands;
using Core.Entities;

namespace DAL.Commands.UpdateParameter
{
    public class UpdateParameterCommand : ICommand
    {
        public UpdateParameterCommand(Parameter parameter)
        {
            Parameter = parameter;
        }

        public Parameter Parameter { get; set; }
    }
}
