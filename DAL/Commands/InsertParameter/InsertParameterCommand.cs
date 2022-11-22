using Core.Commands;

namespace DAL.Commands.InsertParameter
{
	public class InsertParameterCommand : ICommand
	{
		public InsertParameterCommand(
			int year,
			double minThreshold,
			double totalIncomeTaxPercentage,
			double healthAndSocialInsurancePercentage,
			double maxThreshold)
		{
			Year = year;
			MinThreshold = minThreshold;
			TotalIncomeTaxPercentage = totalIncomeTaxPercentage;
			HealthAndSocialInsurancePercentage = healthAndSocialInsurancePercentage;
			MaxThreshold = maxThreshold;
		}

		public int Year { get; set; }

		public double MinThreshold { get; set; }

		public double TotalIncomeTaxPercentage { get; set; }

		public double HealthAndSocialInsurancePercentage { get; set; }

		public double MaxThreshold { get; set; }
	}
}
