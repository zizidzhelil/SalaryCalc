using Common.LogResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace SalaryCalc.Controllers
{
    [ApiController]
    [Route("salary")]
    public class SalaryController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public SalaryController(ILogger<SalaryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
