using Core.Entities;
using MediatR;

namespace Services.Models.EmployeeParameterModels.RequestModels
{
    public class PostEmployeeParameterRequestModel : IRequest
    {
        public int EmployeeId { get; set; }

        public int ParameterId { get; set; }

        public double AnnualSalary { get; set; }

        public EmployeeParameter ToEmployeeParameter()
        {
            return new EmployeeParameter
            {
                EmployeeId = EmployeeId,
                ParameterId = ParameterId,
                AnnualSalary = AnnualSalary
            };
        }
    }
}
