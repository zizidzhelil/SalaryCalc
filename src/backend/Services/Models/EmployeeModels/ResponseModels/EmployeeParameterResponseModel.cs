using Core.Entities;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Models.EmployeeModels.ResponseModels
{
    public class EmployeeParameterResponseModel
    {
        public EmployeeParameterResponseModel()
        {
            Id = 0;
            EmployeeId = 0;
            ParameterId = 0;
            AnnualSalary = 0;
        }

        public EmployeeParameterResponseModel(EmployeeParameter employeeParameter)
        {
            if (employeeParameter != null)
            {
                Id = employeeParameter.Id;
                EmployeeId = employeeParameter.EmployeeId;
                ParameterId = employeeParameter.ParameterId;
                AnnualSalary = employeeParameter.AnnualSalary;

                if (employeeParameter.Parameter != null)
                {
                    Parameters = new ParametersResponseModel(employeeParameter.Parameter);
                }
            }
        }

        public int Id { get; }

        public int EmployeeId { get; }

        public int ParameterId { get; }

        public double AnnualSalary { get; }

        public ParametersResponseModel Parameters { get; set; }
    }
}
