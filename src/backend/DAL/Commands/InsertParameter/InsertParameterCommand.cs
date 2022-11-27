using Core.Commands;
using Core.Entities;

namespace DAL.Commands.InsertParameter
{
    public class InsertParameterCommand : ICommand
    {
        public InsertParameterCommand(Parameter parameter)
        {
            Parameter = parameter;
        }

        public Parameter Parameter { get; }
    }
}
