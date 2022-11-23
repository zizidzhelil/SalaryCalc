using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllParameters;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Handlers.ParameterHandlers
{
	public class GetParametersHandler : IRequestHandler<GetParametersRequestModel, IList<ParametersResponseModel>>
	{
		private readonly IQueryHandler<GetAllParametersQuery, IList<Parameter>> _queryHandler;
		private readonly ILogger _logger;
		public GetParametersHandler(
			IQueryHandler<GetAllParametersQuery, IList<Parameter>> queryHandler,
			ILogger<GetParametersHandler> logger)
		{
			this._queryHandler = queryHandler;
			_logger = logger;
		}

		public async Task<IList<ParametersResponseModel>> Handle(GetParametersRequestModel request, CancellationToken cancellationToken)
		{
			IList<Parameter> parameters = await _queryHandler.HandleAsync(new GetAllParametersQuery(), cancellationToken);

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<ParametersResponseModel>)));
			IList<ParametersResponseModel> parametersResponse = parameters.Select(p => new ParametersResponseModel(p)).ToList();
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<ParametersResponseModel>)));

			return parametersResponse;
		}
	}
}
