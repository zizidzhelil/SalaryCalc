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
		public ParameterController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IList<ParametersResponseModel>> Get()
		{
			IList<ParametersResponseModel> parameters = await _mediator.Send(new GetParametersRequestModel());
			return parameters;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PostParameterRequestModel model)
		{
			await _mediator.Send(model);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] PutParameterRequestModel model)
		{
			await _mediator.Send(model);
			return NoContent();
		}
	}
}
