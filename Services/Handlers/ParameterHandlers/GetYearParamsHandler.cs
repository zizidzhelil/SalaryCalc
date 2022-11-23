using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetYearParams;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Handlers.ParameterHandlers
{
	public class GetYearParamsHandler : IRequestHandler<GetYearParamsRequestModel, ParametersResponseModel>
	{
		private readonly ILogger _logger;
		private readonly IValidation<GetYearParamsRequestModel> _validator;
		private readonly IQueryHandler<GetYearParamsQuery, Parameter> _queryHandler;

		public GetYearParamsHandler(
			ILogger<GetYearParamsHandler> logger, 
			IValidation<GetYearParamsRequestModel> validator, 
			IQueryHandler<GetYearParamsQuery, Parameter> queryHandler)
		{
			_logger = logger;
			_validator = validator;
			_queryHandler = queryHandler;
		}

		public async Task<ParametersResponseModel> Handle(GetYearParamsRequestModel request, CancellationToken cancellationToken)
		{
			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(GetYearParamsRequestModel)));
			await _validator.Validate(request);
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(GetYearParamsRequestModel)));

			Parameter parameter = await _queryHandler.HandleAsync(new GetYearParamsQuery(request.Year));

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(ParametersResponseModel)));
			ParametersResponseModel parameterResponse = new ParametersResponseModel(parameter);
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(ParametersResponseModel)));

			return parameterResponse;
		}
	}
}
