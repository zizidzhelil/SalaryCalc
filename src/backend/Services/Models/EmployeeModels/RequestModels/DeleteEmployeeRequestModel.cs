using MediatR;

namespace Services.Models.EmployeeModels.RequestModels
{
    public class DeleteEmployeeRequestModel : IRequest
    {
        public DeleteEmployeeRequestModel(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
