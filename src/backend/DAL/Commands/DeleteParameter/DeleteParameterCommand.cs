using Core.Commands;

namespace DAL.Commands.DeleteParameter
{
    public class DeleteParameterCommand : ICommand
    {
        public DeleteParameterCommand(int year)
        {
            Year = year;
        }

        public int Year { get; set; }
    }
}
