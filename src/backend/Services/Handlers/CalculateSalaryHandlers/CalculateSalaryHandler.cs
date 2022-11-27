using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using DAL.Queries.GetEmpAnnualSalaryForYear;
using DAL.Queries.GetYearParams;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.CalculateSalaryModels.RequestModels;
using Services.Models.CalculateSalaryModels.ResponseModels;

namespace Services.Handlers.CalculateSalaryHandlers
{
    public class CalculateSalaryHandler : IRequestHandler<CalculateSalaryRequestModel, CalculateSalaryResponseModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<CalculateSalaryRequestModel> _validator;
        private readonly IQueryHandler<GetYearParamsQuery, Parameter> _yearParamsQueryHandler;
        private readonly IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> _empAnnualSalaryForYearQueryHandler;

        public CalculateSalaryHandler(
            ILogger<CalculateSalaryHandler> logger,
            IValidation<CalculateSalaryRequestModel> validator,
            IQueryHandler<GetYearParamsQuery, Parameter> yearParamsQueryHandler,
            IQueryHandler<GetEmpAnnualSalaryForYearQuery, EmployeeParameter> empAnnualSalaryForYearQueryHandler)
        {
            _logger = logger;
            _validator = validator;
            _yearParamsQueryHandler = yearParamsQueryHandler;
            _empAnnualSalaryForYearQueryHandler = empAnnualSalaryForYearQueryHandler;
        }

        public async Task<CalculateSalaryResponseModel> Handle(CalculateSalaryRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin class {nameof(CalculateSalaryHandler)} and method {nameof(CalculateSalaryHandler.Handle)}");
            await _validator.Validate(request, cancellationToken);

            Parameter yearParameters = await _yearParamsQueryHandler.HandleAsync(new GetYearParamsQuery(request.Year), cancellationToken);

            if (request.GrossSalary == 0)
            {
                var employeeParameter = await _empAnnualSalaryForYearQueryHandler.HandleAsync(
                    new GetEmpAnnualSalaryForYearQuery(request.Year, request.EmployeeId), cancellationToken);

                request.GrossSalary = employeeParameter.AnnualSalary;
            }

            SalaryAndTaxes salaryAndTaxes = new()
            {
                GrossSalary = request.GrossSalary
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

            CalculateSalaryResponseModel salaryAndTaxesResponse = new(salaryAndTaxes.NetSalary, salaryAndTaxes.TaxTotalIncome, salaryAndTaxes.TaxHealthAndSocialInsurance);
            _logger.LogInformation($"End class {nameof(CalculateSalaryHandler)} and method {nameof(CalculateSalaryHandler.Handle)}");

            return salaryAndTaxesResponse;
        }
    }
}
