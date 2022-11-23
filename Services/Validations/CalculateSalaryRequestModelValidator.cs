using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using Services.Models.CalculateSalaryModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class CalculateSalaryRequestModelValidator : IValidation<CalculateSalaryRequestModel>
	{
		private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _employeesQueryHandler;

		public CalculateSalaryRequestModelValidator(IQueryHandler<GetAllEmployeesQuery, IList<Employee>> employeesQueryHandler)
		{
			_employeesQueryHandler = employeesQueryHandler;
		}

		public async Task Validate(CalculateSalaryRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			IList<Employee> employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);
			if(!employees.Any(x => x.Id == model.EmployeeId))
			{
				string message = $"Employee with id {model.EmployeeId} not found";
				errorMessages.Add(message);
			}

			Regex yearRegex = new("[12]\\d{3}");
			if (!yearRegex.IsMatch(model.Year.ToString()))
			{
				string message = $"{nameof(model.Year)} is invalid";
				errorMessages.Add(message);
			}

			if (model.GrossSalary <= 0)
			{
				string message = $"{nameof(model.GrossSalary)} must be greater than 0";
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
