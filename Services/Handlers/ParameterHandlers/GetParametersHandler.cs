using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllParameters;
using MediatR;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Handlers.ParameterHandlers
{
	public class GetParametersHandler : IRequestHandler<GetParametersRequestModel, IList<ParametersResponseModel>>
	{
		private readonly IQueryHandler<GetAllParametersQuery, IList<Parameter>> _queryHandler;

		public GetParametersHandler(IQueryHandler<GetAllParametersQuery, IList<Parameter>> queryHandler)
		{
			this._queryHandler = queryHandler;
		}

		public async Task<IList<ParametersResponseModel>> Handle(GetParametersRequestModel request, CancellationToken cancellationToken)
		{
			IList<Parameter> parameters = await _queryHandler.HandleAsync(new GetAllParametersQuery(), cancellationToken);
			IList<ParametersResponseModel> parametersResponse = parameters.Select(p => new ParametersResponseModel(p)).ToList();

			return parametersResponse;
		}
	}
}
