using MediatR;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Models.ParameterModels.RequestModels
{
	public class GetYearParamsRequestModel : IRequest<ParametersResponseModel>
	{
		public GetYearParamsRequestModel(int year)
		{
			Year = year;
		}

		public int Year { get; set; }
	}
}
