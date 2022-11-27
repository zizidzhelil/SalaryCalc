using Core.Entities;

namespace Services.Models.ParameterModels.ResponseModels
{
    public class ParametersResponseModel
    {
        public ParametersResponseModel()
        {
            Id = 0;
            Year = 0;
            MinThreshold = 0;
            TotalIncomeTaxPercentage = 0;
            HealthAndSocialInsurancePercentage = 0;
            MaxThreshold = 0;
        }

        public ParametersResponseModel(Parameter parameter)
        {
            if (parameter != null)
            {
                Id = parameter.Id;
                Year = parameter.Year;
                MinThreshold = parameter.MinThreshold;
                MaxThreshold = parameter.MaxThreshold;
                TotalIncomeTaxPercentage = parameter.TotalIncomeTaxPercentage;
                HealthAndSocialInsurancePercentage = parameter.HealthAndSocialInsurancePercentage;
            }
        }

        public int Id { get; set; }

        public int Year { get; set; }

        public double MinThreshold { get; set; }

        public double TotalIncomeTaxPercentage { get; set; }

        public double HealthAndSocialInsurancePercentage { get; set; }

        public double MaxThreshold { get; set; }
    }
}
