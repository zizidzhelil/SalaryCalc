using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetEmployeeParameter;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Handlers.ParameterHandlers
{
    public class GetEmployeeParameterHandler : IRequestHandler<GetEmployeeParameterRequestModel, IList<GetEmployeeParameterResponseModel>>
    {
        private readonly IQueryHandler<GetEmployeeParameterQuery, IList<EmployeeParameter>> _queryHandler;
        private readonly ILogger _logger;
        public GetEmployeeParameterHandler(
           IQueryHandler<GetEmployeeParameterQuery, IList<EmployeeParameter>> queryHandler,
            ILogger<GetEmployeeParameterHandler> logger)
        {
            _queryHandler = queryHandler;
            _logger = logger;
        }

        public async Task<IList<GetEmployeeParameterResponseModel>> Handle(GetEmployeeParameterRequestModel request, CancellationToken cancellationToken)
        {
            IList<EmployeeParameter> employeeParameters = await _queryHandler.HandleAsync(new GetEmployeeParameterQuery(request.EmployeeId), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<EmployeeParameter>)));
            IList<GetEmployeeParameterResponseModel> employeeParametersResponse = employeeParameters.Select(e => new GetEmployeeParameterResponseModel(e)).ToList();
            _logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<EmployeeParameter>)));

            return employeeParametersResponse;
        }
    }
}
