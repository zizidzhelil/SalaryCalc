using Core.Commands;
using Core.Models;

namespace Services.Commands.UpdateParameters
{
    public class UpdateParametersCommand : ICommand
    {
        public UpdateParametersCommand(ParameterModel parameter)
        {
          Parameter = parameter;
        }

        public ParameterModel Parameter { get; }
    }
}
