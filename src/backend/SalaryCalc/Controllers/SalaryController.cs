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
            _logger.LogInformation($"Begin class {nameof(SalaryController)} and method {nameof(SalaryController.GetNetSalary)}");

            CalculateSalaryResponseModel salaryResponse = await _mediator.Send(new CalculateSalaryRequestModel(employeeId, year, grossSalary));

            _logger.LogInformation($"End class {nameof(SalaryController)} and method {nameof(SalaryController.GetNetSalary)}");
            return Ok(salaryResponse);
        }
    }
}
