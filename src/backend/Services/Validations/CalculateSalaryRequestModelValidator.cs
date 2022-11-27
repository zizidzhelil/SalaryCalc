using Common.Exceptions;
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
            _logger.LogInformation($"Begin class {nameof(CalculateSalaryRequestModelValidator)} and method {nameof(CalculateSalaryRequestModelValidator.Validate)}");

            List<string> errorMessages = new List<string>();

            IList<Employee> employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery(), cancellationToken);
            if (!employees.Any(x => x.Id == model.EmployeeId))
            {
                string message = $"Employee with id {model.EmployeeId} not found";
                errorMessages.Add(message);
            }

            var year = employees.Where(e => e.Id == model.EmployeeId).SelectMany(e => e.Parameters);
            if (!year.Any(y => y.Parameter.Year == model.Year))
            {
                string message = $"Employee does not have a record for year {model.Year}";
                errorMessages.Add(message);
            }

            Regex yearRegex = new("[12]\\d{3}");
            if (!yearRegex.IsMatch(model.Year.ToString()))
            {
                string message = $"{nameof(model.Year)} is invalid";
                errorMessages.Add(message);
            }

            _logger.LogInformation($"End class {nameof(CalculateSalaryRequestModelValidator)} and method {nameof(CalculateSalaryRequestModelValidator.Validate)}");
            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }
        }
    }
}
