using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;

namespace SalaryCalc.Controllers
{
	[ApiController]
	[Route("employee")]
	public class EmployeeController : ControllerBase
	{
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

		public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
		{
            _logger = logger;
            _mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(EmployeeController), nameof(Get)));

			IList<EmployeesResponseModel> employeessResponse = await _mediator.Send(new GetEmployeesRequestModel());
			return Ok(employeessResponse);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PostEmployeeRequestModel model)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(EmployeeController), nameof(Post)));

			await _mediator.Send(model);
			return NoContent();
		}
	}
}
