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

		public SalaryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<CalculateSalaryResponseModel> GetNetSalary([FromQuery] int employeeId, int year, double grossSalary)
		{
			CalculateSalaryResponseModel salaryResponse = await _mediator.Send(new CalculateSalaryRequestModel(employeeId, year, grossSalary));
			return salaryResponse;
		}
	}
}
