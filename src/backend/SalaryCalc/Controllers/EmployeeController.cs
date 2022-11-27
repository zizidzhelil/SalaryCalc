using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
using Services.Models.EmployeeParameterModels.RequestModels;

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
            _logger.LogInformation($"Begin class {nameof(EmployeeController)} and method {nameof(EmployeeController.Get)}");

            IList<EmployeesResponseModel> employeessResponse = await _mediator.Send(new GetEmployeesRequestModel());

            _logger.LogInformation($"End class {nameof(EmployeeController)} and method {nameof(EmployeeController.Get)}");
            return Ok(employeessResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostEmployeeRequestModel model)
        {
            _logger.LogInformation($"Begin class {nameof(EmployeeController)} and method {nameof(EmployeeController.Post)}");

            await _mediator.Send(model);

            _logger.LogInformation($"End class {nameof(EmployeeController)} and method {nameof(EmployeeController.Post)}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Begin class {nameof(EmployeeController)} and method {nameof(EmployeeController.Delete)}");

            await _mediator.Send(new DeleteEmployeeRequestModel(id));

            _logger.LogInformation($"End class {nameof(EmployeeController)} and method {nameof(EmployeeController.Delete)}");
            return NoContent();
        }

        [HttpPost("parameter")]
        public async Task<IActionResult> PostEmployeeParameter([FromBody] PostEmployeeParameterRequestModel model)
        {
            _logger.LogInformation($"Begin class {nameof(EmployeeController)} and method {nameof(EmployeeController.PostEmployeeParameter)}");

            await _mediator.Send(model);

            _logger.LogInformation($"End class {nameof(EmployeeController)} and method {nameof(EmployeeController.PostEmployeeParameter)}");
            return NoContent();
        }

        [HttpDelete("parameter/{id}")]
        public async Task<IActionResult> DeleteEmployeeParameter(int id)
        {
            _logger.LogInformation($"Begin class {nameof(EmployeeController)} and method {nameof(EmployeeController.DeleteEmployeeParameter)}");

            await _mediator.Send(new DeleteEmployeeParameterRequestModel(id));

            _logger.LogInformation($"End class {nameof(EmployeeController)} and method {nameof(EmployeeController.DeleteEmployeeParameter)}");
            return NoContent();
        }
    }
}
