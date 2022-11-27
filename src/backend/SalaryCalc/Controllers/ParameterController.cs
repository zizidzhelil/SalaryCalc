using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.EmployeeModels.RequestModels;
using Services.Models.EmployeeModels.ResponseModels;
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
            _logger.LogInformation($"Begin class {nameof(ParameterController)} and method {nameof(ParameterController.Get)}");

            IList<ParametersResponseModel> parametersResponse = await _mediator.Send(new GetParametersRequestModel());

            _logger.LogInformation($"End class {nameof(ParameterController)} and method {nameof(ParameterController.Get)}");
            return Ok(parametersResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostParameterRequestModel model)
        {
            _logger.LogInformation($"Begin class {nameof(ParameterController)} and method {nameof(ParameterController.Post)}");

            await _mediator.Send(model);

            _logger.LogInformation($"End class {nameof(ParameterController)} and method {nameof(ParameterController.Post)}");
            return NoContent();
        }

        [HttpDelete("{year}")]
        public async Task<IActionResult> Delete(int year)
        {
            _logger.LogInformation($"Begin class {nameof(ParameterController)} and method {nameof(ParameterController.Delete)}");

            await _mediator.Send(new DeleteParameterRequestModel(year));

            _logger.LogInformation($"End class {nameof(ParameterController)} and method {nameof(ParameterController.Delete)}");
            return NoContent();
        }
    }
}
