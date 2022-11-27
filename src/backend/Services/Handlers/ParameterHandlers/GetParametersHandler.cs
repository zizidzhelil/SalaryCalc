using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllEmployees;
using DAL.Queries.GetAllParameters;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Handlers.StudentHandlers;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.ParameterHandlers
{
    public class GetParametersHandler : IRequestHandler<GetParametersRequestModel, IList<ParametersResponseModel>>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllParametersQuery, IList<Parameter>> _queryHandler;

        public GetParametersHandler(
            ILogger<GetParametersHandler> logger,
            IQueryHandler<GetAllParametersQuery, IList<Parameter>> queryHandler)
        {
            _logger = logger;
            _queryHandler = queryHandler;
        }

        public async Task<IList<ParametersResponseModel>> Handle(GetParametersRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(GetParametersHandler)} and method {nameof(GetParametersHandler.Handle)}");

            IList<Parameter> parameters = await _queryHandler.HandleAsync(new GetAllParametersQuery(), cancellationToken);
            IList<ParametersResponseModel> parametersResponse = parameters.Select(p => new ParametersResponseModel(p)).ToList();

            _logger.LogInformation($"End class {nameof(GetParametersHandler)} and method {nameof(GetParametersHandler.Handle)}");

            return parametersResponse;
        }
    }
}
