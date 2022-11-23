using Core.Validation;
using Services.Models.ParameterModels.RequestModels;

namespace Services.Validations
{
	public class GetYearParamsRequestModelValidator : IValidation<GetYearParamsRequestModel>
	{
		public Task Validate(GetYearParamsRequestModel model, CancellationToken cancellationToken = default)
		{
			return Task.CompletedTask;
		}
	}
}
