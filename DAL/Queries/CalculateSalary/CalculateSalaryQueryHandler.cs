using Core.Entities;
using Core.Queries;

namespace DAL.Commands.CalculateSalary
{
	public class CalculateSalaryQueryHandler : IQueryHandler<CalculateSalaryQuery, SalaryAndTaxes>
	{
		private readonly SalaryCalcContext _context;

		public CalculateSalaryQueryHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task<SalaryAndTaxes> HandleAsync(CalculateSalaryQuery query, CancellationToken cancellationToken = default)
		{
			Parameter parameter = await _context.Parameters.FindAsync(query.Year);

			SalaryAndTaxes salaryAndTaxes = new ()
			{
				GrossSalary = query.GrossSalary
			};

			if (query.GrossSalary <= parameter.MinThreshold)
			{
				salaryAndTaxes.TaxHealthAndSocialInsurance = 0;
				salaryAndTaxes.TaxTotalIncome = 0;
			}
			else
			{
				salaryAndTaxes.TaxTotalIncome = parameter.TotalIncomeTaxPercentage * query.GrossSalary / 100;

				if (query.GrossSalary <= parameter.MaxThreshold)
				{
					salaryAndTaxes.TaxHealthAndSocialInsurance = parameter.HealthAndSocialInsurancePercentage * query.GrossSalary / 100;
				}
				else
				{
					salaryAndTaxes.TaxHealthAndSocialInsurance = parameter.HealthAndSocialInsurancePercentage * parameter.MaxThreshold / 100;
				}
			}

			return salaryAndTaxes;
		}
	}
}
