using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace SalaryCalc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SalaryController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger _logger;

		public SalaryController(IMediator mediator, ILogger<SalaryController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetNetSalary([FromQuery] int employeeId, int year, double grossSalary)
		{
			_logger.LogInformation(LogEvents.ControllerFound, string.Format(LogMessageResources.ControllerFound, nameof(SalaryController), nameof(GetNetSalary)));

			CalculateSalaryResponseModel salaryResponse = await _mediator.Send(new CalculateSalaryRequestModel(employeeId, year, grossSalary));
			return Ok(salaryResponse);
		}
	}
}
