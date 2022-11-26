using Core.Models;
using Core.Queries;

namespace Services.Queries.GetParameters
{
    public class GetParametersQuery : IQuery<ParameterModel>
    {
        public GetParametersQuery(int year)
        {
            Year= year;
        }

        public int Year { get; }
    }
}
