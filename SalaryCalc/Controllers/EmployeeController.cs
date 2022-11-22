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

		public EmployeeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IList<EmployeesResponseModel>> Get()
		{
			IList<EmployeesResponseModel> employeessResponse = await _mediator.Send(new GetEmployeesRequestModel());
			return employeessResponse;
		}
	}
}
