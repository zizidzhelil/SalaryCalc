using MediatR;

namespace Services.Models.EmployeeParameterModels.RequestModels
{
    public class DeleteEmployeeParameterRequestModel : IRequest
    {
        public DeleteEmployeeParameterRequestModel(int employeeParameterId)
        {
            EmployeeParameterId = employeeParameterId;
        }

        public int EmployeeParameterId { get; set; }
    }
}
