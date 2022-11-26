using MediatR;

namespace Services.Models.ParameterModels.RequestModels
{
	public class PostParameterRequestModel : IRequest
	{
		public int Year { get; set; }

		public double MinThreshold { get; set; }

		public double TotalIncomeTaxPercentage { get; set; }

		public double HealthAndSocialInsurancePercentage { get; set; }

		public double MaxThreshold { get; set; }
	}
}
