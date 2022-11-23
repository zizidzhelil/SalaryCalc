using Common.Exceptions;
using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Services.Models.CalculateSalaryModels.RequestModels;
using System.Text.RegularExpressions;

namespace Services.Validations
{
	public class CalculateSalaryRequestModelValidator : IValidation<CalculateSalaryRequestModel>
	{
		private readonly ILogger _logger;
		private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _employeesQueryHandler;

		public CalculateSalaryRequestModelValidator(
			ILogger<CalculateSalaryRequestModelValidator> logger,
			IQueryHandler<GetAllEmployeesQuery, IList<Employee>> employeesQueryHandler)
		{
			_logger = logger;
			_employeesQueryHandler = employeesQueryHandler;
		}

		public async Task Validate(CalculateSalaryRequestModel model, CancellationToken cancellationToken = default)
		{
			List<string> errorMessages = new List<string>();

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.EmployeeId)));
			IList<Employee> employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);
			if(!employees.Any(x => x.Id == model.EmployeeId))
			{
				string message = $"Employee with id {model.EmployeeId} not found";
				_logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.EmployeeId), message));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.EmployeeId)));

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.Year)));
			Regex yearRegex = new("[12]\\d{3}");
			if (!yearRegex.IsMatch(model.Year.ToString()))
			{
				string message = $"{nameof(model.Year)} is invalid";
				_logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.Year), message));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.Year)));

			_logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.GrossSalary)));
			if (model.GrossSalary <= 0)
			{
				string message = $"{nameof(model.GrossSalary)} must be greater than 0";
				_logger.LogInformation(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.GrossSalary)));
				errorMessages.Add(message);
			}
			_logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.GrossSalary)));


			if (errorMessages.Any())
			{
				string message = string.Join(Environment.NewLine, errorMessages);
				throw new NotFoundException(message);
			}
		}
	}
}
