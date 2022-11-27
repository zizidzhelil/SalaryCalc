using Core.Entities;

namespace DAL.Seed
{
    public class ParameterSeed
    {
        public ParameterSeed()
        {
            Parameters = new List<Parameter>()
            {
                new Parameter() {Id = 1, Year = 2023, MinThreshold = 1200, MaxThreshold = 3300, HealthAndSocialInsurancePercentage = 16, TotalIncomeTaxPercentage = 12},
                new Parameter() {Id = 2, Year = 2022, MinThreshold = 1000, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 10},
                new Parameter() {Id = 3, Year = 2021, MinThreshold = 950, MaxThreshold = 3000, HealthAndSocialInsurancePercentage = 15, TotalIncomeTaxPercentage = 9},
                new Parameter() {Id = 4, Year = 2020, MinThreshold = 900, MaxThreshold = 2800, HealthAndSocialInsurancePercentage = 13, TotalIncomeTaxPercentage = 9},
                new Parameter() {Id = 5, Year = 2019, MinThreshold = 850, MaxThreshold = 2700, HealthAndSocialInsurancePercentage = 12, TotalIncomeTaxPercentage = 8},
                new Parameter() {Id = 6, Year = 2018, MinThreshold = 800, MaxThreshold = 2500, HealthAndSocialInsurancePercentage = 12, TotalIncomeTaxPercentage = 8},
                new Parameter() {Id = 7, Year = 2017, MinThreshold = 700, MaxThreshold = 2400, HealthAndSocialInsurancePercentage = 10, TotalIncomeTaxPercentage = 8},
                new Parameter() {Id = 8, Year = 2016, MinThreshold = 650, MaxThreshold = 2300, HealthAndSocialInsurancePercentage = 10, TotalIncomeTaxPercentage = 7},
                new Parameter() {Id = 9, Year = 2015, MinThreshold = 600, MaxThreshold = 2000, HealthAndSocialInsurancePercentage = 9, TotalIncomeTaxPercentage = 7}
            };
        }

        public List<Parameter> Parameters { get; }
    }
}
