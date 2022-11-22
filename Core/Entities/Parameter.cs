namespace Core.Entities
{
    public class Parameter
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public double MinThreshold { get; set; }

        public double TotalIncomeTaxPercentage { get; set; }

        public double HealthAndSocialInsurancePercentage { get; set; }

        public double MaxThreshold { get; set; }

        public Employee Employee { get; set; }
    }
}
