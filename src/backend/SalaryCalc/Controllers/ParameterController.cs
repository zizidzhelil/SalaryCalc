using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace SalaryCalc.Controllers
{
	[ApiController]
	[Route("parameter")]
	public class ParameterController : ControllerBase
	{
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
		public ParameterController(ILogger<ParameterController> logger, IMediator mediator)
		{
            _logger = logger;
            _mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(Get)));

			IList<ParametersResponseModel> parameters = await _mediator.Send(new GetParametersRequestModel());
			return Ok(parameters);
		}

		[HttpGet("get-by-year")]
		public async Task<IActionResult> GetByYear([FromQuery] int year)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(GetByYear)));

			ParametersResponseModel parameter = await _mediator.Send(new GetYearParamsRequestModel(year));
			return Ok(parameter);
		}

		[HttpGet("get-by-employee-id")]
        public async Task<IActionResult> GetByEmployeeId([FromQuery] int employeeId)
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(GetByEmployeeId)));

            IList<GetEmployeeParameterResponseModel> getEmployeeParameters = await _mediator.Send(new GetEmployeeParameterRequestModel(employeeId));
            return Ok(getEmployeeParameters);
        }

        [HttpPost]
		public async Task<IActionResult> Post([FromBody] PostParameterRequestModel model)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(Post)));

			await _mediator.Send(model);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] PutParameterRequestModel model)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(Put)));

			await _mediator.Send(model);
			return NoContent();
		}
	}
}
