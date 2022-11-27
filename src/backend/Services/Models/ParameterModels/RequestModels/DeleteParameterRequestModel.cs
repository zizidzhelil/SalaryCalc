using MediatR;

namespace Services.Models.ParameterModels.RequestModels
{
    public class DeleteParameterRequestModel : IRequest
    {
        public DeleteParameterRequestModel(int parameterId)
        {
            Year = parameterId;
        }

        public int Year { get; set; }
    }
}
