using Core.Entities;

namespace Services.Models.EmployeeModels.ResponseModels
{
    public class GetEmpAnnualSalaryForYearResponseModel
    {
        public GetEmpAnnualSalaryForYearResponseModel()
        {
            Id = 0;
            EmployeeId = 0;
            Year = 0;
            AnnualSalary = 0;
        }

        public GetEmpAnnualSalaryForYearResponseModel(EmployeeParameter employeeParameter)
        {
            if (employeeParameter != null)
            {
                Id = employeeParameter.Id;
                EmployeeId = employeeParameter.EmployeeId;
                Year = employeeParameter.Year;
                AnnualSalary = employeeParameter.AnnualSalary;
            }
        }

        public int Id { get; }

        public int EmployeeId { get; }

        public int Year { get; }

        public double AnnualSalary { get; }
    }
}
