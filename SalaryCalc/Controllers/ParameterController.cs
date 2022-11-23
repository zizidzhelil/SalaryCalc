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
		public ParameterController(IMediator mediator, ILogger logger)
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
