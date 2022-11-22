using Core.Entities;

namespace Services.Models.ParameterModels.ResponseModels
{
	public class ParametersResponseModel
	{
		public ParametersResponseModel()
		{
		}

		public ParametersResponseModel(Parameter parameter)
		{
			if(parameter != null)
			{
				Year = parameter.Year;
				MinThreshold = parameter.MinThreshold;
				MaxThreshold = parameter.MaxThreshold;
				TotalIncomeTaxPercentage = parameter.TotalIncomeTaxPercentage;
				HealthAndSocialInsurancePercentage = parameter.HealthAndSocialInsurancePercentage;
			}
		}

		public int Year { get; set; }

		public double MinThreshold { get; set; }

		public double TotalIncomeTaxPercentage { get; set; }

		public double HealthAndSocialInsurancePercentage { get; set; }

		public double MaxThreshold { get; set; }
	}
}
