using Common.Exceptions;
using Core.Validation;
using Services.Models.EmployeeModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class PostEmployeeRequestModelValidator : IValidation<PostEmployeeRequestModel>
	{
		public async Task Validate(PostEmployeeRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			if(model.BirthDate.Year < DateTime.Today.AddYears(-80).Year 
				|| model.BirthDate.Year > DateTime.Today.AddYears(-15).Year)
			{
				string message = $"{nameof(model.BirthDate)} is invalid";
				errorMessages.Add(message);
			}

			Regex nameRegex = new("[a-zA-Z]+");
			if (!nameRegex.IsMatch(model.FirstName))
			{
				string message = $"Invalid {nameof(model.FirstName)} given";
				errorMessages.Add(message);
			}

			if (!nameRegex.IsMatch(model.MiddleName))
			{
				string message = $"Invalid {nameof(model.MiddleName)} given";
				errorMessages.Add(message);
			}

			if (!nameRegex.IsMatch(model.LastName))
			{
				string message = $"Invalid {nameof(model.LastName)} given";
				errorMessages.Add(message);
			}

			if (errorMessages.Any())
			{
				string message = string.Join(Environment.NewLine, errorMessages);
				throw new NotFoundException(message);
			}
		}
	}
}
