using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetYearParams
{
	public class GetYearParamsQuery : IQuery<Parameter>
	{
		public GetYearParamsQuery(int year)
		{
			Year = year;
		}

		public int Year { get; }
	}
}
