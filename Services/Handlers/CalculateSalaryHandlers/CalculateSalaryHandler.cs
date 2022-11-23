using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetYearParams;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Handlers.CalculateSalaryHandlers
{
	public class CalculateSalaryHandler : IRequestHandler<CalculateSalaryRequestModel, CalculateSalaryResponseModel>
	{
		private readonly IQueryHandler<GetYearParamsQuery, Parameter> _queryHandler;
		private readonly IValidation<CalculateSalaryRequestModel> _validator;
		private readonly ILogger _logger;

		public CalculateSalaryHandler(
			IQueryHandler<GetYearParamsQuery, Parameter> queryHandler,
			IValidation<CalculateSalaryRequestModel> validator,
			ILogger<CalculateSalaryHandler> logger)
		{
			_queryHandler = queryHandler;
			_validator = validator;
			_logger = logger;
		}

		public async Task<CalculateSalaryResponseModel> Handle(CalculateSalaryRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			Parameter yearParameters = await _queryHandler.HandleAsync(new GetYearParamsQuery(request.Year));

			if(request.GrossSalary == null)
			{

			}
			
			SalaryAndTaxes salaryAndTaxes = new()
			{
				GrossSalary = request.GrossSalary //TODO: or from db
			};

			if (request.GrossSalary <= yearParameters.MinThreshold)
			{
				salaryAndTaxes.TaxHealthAndSocialInsurance = 0;
				salaryAndTaxes.TaxTotalIncome = 0;
			}
			else
			{
				salaryAndTaxes.TaxTotalIncome = yearParameters.TotalIncomeTaxPercentage * request.GrossSalary / 100;

				if (request.GrossSalary <= yearParameters.MaxThreshold)
				{
					salaryAndTaxes.TaxHealthAndSocialInsurance = yearParameters.HealthAndSocialInsurancePercentage * request.GrossSalary / 100;
				}
				else
				{
					salaryAndTaxes.TaxHealthAndSocialInsurance = yearParameters.HealthAndSocialInsurancePercentage * yearParameters.MaxThreshold / 100;
				}
			}

			_logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(CalculateSalaryResponseModel)));
			CalculateSalaryResponseModel salaryAndTaxesResponse = new(salaryAndTaxes.NetSalary, salaryAndTaxes.TaxTotalIncome, salaryAndTaxes.TaxHealthAndSocialInsurance);
			_logger.LogInformation(LogEvents.AssembledResponse, string.Format(LogMessageResources.AssembledResponse, nameof(CalculateSalaryResponseModel)));
			return salaryAndTaxesResponse;
		}
	}
}
