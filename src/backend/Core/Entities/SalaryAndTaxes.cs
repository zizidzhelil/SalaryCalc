namespace Core.Entities
{
	public class SalaryAndTaxes
	{
		public double NetSalary => GrossSalary - (TaxTotalIncome + TaxHealthAndSocialInsurance);

		public double TaxTotalIncome { get; set; }

		public double TaxHealthAndSocialInsurance { get; set; }

		public double GrossSalary { get; set; }
	}
}
