using Core.Entities;
using MediatR;

namespace Services.Models.ParameterModels.RequestModels
{
    public class PutParameterRequestModel : IRequest
    {
        public int Year { get; set; }

        public double MinThreshold { get; set; }

        public double TotalIncomeTaxPercentage { get; set; }

        public double HealthAndSocialInsurancePercentage { get; set; }

        public double MaxThreshold { get; set; }

        public Parameter ToParameter()
        {
            return new Parameter
            {
                Year = Year,
                MinThreshold = MinThreshold,
                TotalIncomeTaxPercentage = TotalIncomeTaxPercentage,
                MaxThreshold = MaxThreshold,
                HealthAndSocialInsurancePercentage = HealthAndSocialInsurancePercentage,
            };
        }
    }
}
