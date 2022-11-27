using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeParameterModels.RequestModels;

namespace Services.Validations
{
    public class PostEmployeeParameterRequestModelValidator : IValidation<PostEmployeeParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _employeesQueryHandler;

        public PostEmployeeParameterRequestModelValidator(
            ILogger<PostEmployeeParameterRequestModelValidator> logger,
            IQueryHandler<GetAllEmployeesQuery, IList<Employee>> employeesQueryHandler)
        {
            _logger = logger;
            _employeesQueryHandler = employeesQueryHandler;
        }

        public async Task Validate(PostEmployeeParameterRequestModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(PostEmployeeParameterRequestModelValidator)} and method {nameof(PostEmployeeParameterRequestModelValidator.Validate)}");

            List<string> errorMessages = new List<string>();

            var employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery());
            if (!employees.Any(e => !e.Parameters.Any(p => p.ParameterId == model.ParameterId)))
            {
                errorMessages.Add($"Employee parameter with id {model.ParameterId} does not exists");
            }

            if (!employees.Any(e => e.Id == model.EmployeeId))
            {
                errorMessages.Add($"Employee with id {model.EmployeeId} does not exists");
            }

            if (model.AnnualSalary < 0)
            {
                errorMessages.Add($"Salary cannot be negative");
            }

            _logger.LogInformation($"End class {nameof(PostEmployeeParameterRequestModelValidator)} and method {nameof(PostEmployeeParameterRequestModelValidator.Validate)}");
            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }
        }
    }
}
