using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;

namespace SalaryCalc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger _logger;

		public EmployeeController(IMediator mediator, ILogger logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IList<EmployeesResponseModel>> Get()
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(EmployeeController), nameof(Get)));

			IList<EmployeesResponseModel> employeessResponse = await _mediator.Send(new GetEmployeesRequestModel());
			return employeessResponse;
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
