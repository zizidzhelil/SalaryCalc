using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Commands.CalculateSalary;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Handlers.CalculateSalaryHandlers
{
	public class CalculateSalaryHandler : IRequestHandler<CalculateSalaryRequestModel, CalculateSalaryResponseModel>
	{
		private readonly IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes> _queryHandler;
		private readonly IValidation<CalculateSalaryRequestModel> _validator;
		private readonly ILogger _logger;

		public CalculateSalaryHandler(
			IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes> queryHandler,
			IValidation<CalculateSalaryRequestModel> validator,
			ILogger logger)
		{
			_queryHandler = queryHandler;
			_validator = validator;
			_logger = logger;
		}

		public async Task<CalculateSalaryResponseModel> Handle(CalculateSalaryRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			SalaryAndTaxes salaryAndTaxes = await _queryHandler.HandleAsync(new CalculateSalaryQuery(request.EmployeeId, request.Year, request.GrossSalary));

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(CalculateSalaryResponseModel)));
			CalculateSalaryResponseModel salaryAndTaxesResponse = new(salaryAndTaxes.NetSalary, salaryAndTaxes.TaxTotalIncome, salaryAndTaxes.TaxHealthAndSocialInsurance);
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(CalculateSalaryResponseModel)));

			return salaryAndTaxesResponse;
		}
	}
}
