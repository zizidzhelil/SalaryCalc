using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Commands.CalculateSalary;
using MediatR;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Handlers.CalculateSalaryHandlers
{
	public class CalculateSalaryHandler : IRequestHandler<CalculateSalaryRequestModel, CalculateSalaryResponseModel>
	{
		private readonly IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes> _queryHandler;
		private readonly IValidation<CalculateSalaryRequestModel> _validator;

		public CalculateSalaryHandler(
			IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes> queryHandler,
			IValidation<CalculateSalaryRequestModel> validator)
		{
			_queryHandler = queryHandler;
			_validator = validator;
		}

		public async Task<CalculateSalaryResponseModel> Handle(CalculateSalaryRequestModel request, CancellationToken cancellationToken)
		{
			await _validator.Validate(request);

			SalaryAndTaxes salaryAndTaxes = await _queryHandler.HandleAsync(new CalculateSalaryQuery(request.EmployeeId, request.Year, request.GrossSalary));
			CalculateSalaryResponseModel salaryAndTaxesResponse = new(salaryAndTaxes.NetSalary, salaryAndTaxes.TaxTotalIncome, salaryAndTaxes.TaxHealthAndSocialInsurance);

			return salaryAndTaxesResponse;
		}
	}
}
