using Core.Commands;
using Core.Models;

namespace Services.Commands.AddYearParameters
{
    public class AddYearParametersCommand : ICommand
    {
        public AddYearParametersCommand(ParameterModel yearParameters)
        {
            YearParameters = yearParameters;
        }

        public ParameterModel YearParameters { get; set; }
    }
}
