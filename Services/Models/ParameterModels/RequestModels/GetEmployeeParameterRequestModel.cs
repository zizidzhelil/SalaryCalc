using MediatR;
using Services.Models.ParameterModels.ResponseModels;

namespace Services.Models.ParameterModels.RequestModels
{
    public class GetEmployeeParameterRequestModel : IRequest<IList<GetEmployeeParameterResponseModel>>
    {
        public GetEmployeeParameterRequestModel(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; set; }
    }
}
