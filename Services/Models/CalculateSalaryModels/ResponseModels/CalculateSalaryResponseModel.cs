namespace Services.Models.CalculateSalaryModels.ResponseModels
{
	public class CalculateSalaryResponseModel
	{
		public CalculateSalaryResponseModel(
			double netSalary,
			double taxTotalIncome,
			double taxHealthAndSocialInsurance)
		{
			NetSalary = netSalary;
			TaxTotalIncome = taxTotalIncome;
			TaxHealthAndSocialInsurance = taxHealthAndSocialInsurance;
		}

		public double NetSalary { get; set; }

		public double TaxTotalIncome { get; set; }

		public double TaxHealthAndSocialInsurance { get; set; }
	}
}
