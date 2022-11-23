﻿using Core.Commands;

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

		public int Year { get; }

		public double MinThreshold { get; }

		public double TotalIncomeTaxPercentage { get; }

		public double HealthAndSocialInsurancePercentage { get; }

		public double MaxThreshold { get; }
	}
}
