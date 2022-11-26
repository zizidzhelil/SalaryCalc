using Core.Entities;

namespace Services.Models.ParameterModels.ResponseModels
{
    public class GetEmployeeParameterResponseModel
    {
        public GetEmployeeParameterResponseModel(EmployeeParameter employeeParameter)
        {
            Id = employeeParameter.Id;
            EmployeeId = employeeParameter.EmployeeId;
            Year = employeeParameter.Year;
            AnnualSalary = employeeParameter.AnnualSalary;
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Year { get; set; }

        public double AnnualSalary { get; set; }
    }
}
