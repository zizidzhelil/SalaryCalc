using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.ParameterModels.RequestModels;
using Services.Models.ParameterModels.ResponseModels;

namespace SalaryCalc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ParameterController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger _logger;
		public ParameterController(IMediator mediator, ILogger<ParameterController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IList<ParametersResponseModel>> Get()
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(Get)));

			IList<ParametersResponseModel> parameters = await _mediator.Send(new GetParametersRequestModel());
			return parameters;
		}

		[HttpGet("GetByYear")]
		public async Task<ParametersResponseModel> GetByYear([FromQuery] int year)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(ParameterController), nameof(GetByYear)));

			ParametersResponseModel parameter = await _mediator.Send(new GetYearParamsRequestModel(year));
			return parameter;
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
