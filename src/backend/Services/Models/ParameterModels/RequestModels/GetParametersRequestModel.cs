using MediatR;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Models.ParameterModels.RequestModels
{
	public class GetParametersRequestModel : IRequest<IList<ParametersResponseModel>>
	{
	}
}
