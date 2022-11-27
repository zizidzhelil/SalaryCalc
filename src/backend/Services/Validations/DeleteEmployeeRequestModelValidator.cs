using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeModels.RequestModels;

namespace Services.Validations
{
    public class DeleteEmployeeRequestModelValidator : IValidation<DeleteEmployeeRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _employeesQueryHandler;

        public DeleteEmployeeRequestModelValidator(
            ILogger<DeleteEmployeeRequestModelValidator> logger,
            IQueryHandler<GetAllEmployeesQuery, IList<Employee>> employeesQueryHandler)
        {
            _logger = logger;
            _employeesQueryHandler = employeesQueryHandler;
        }

        public async Task Validate(DeleteEmployeeRequestModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeRequestModelValidator)} and method {nameof(DeleteEmployeeRequestModelValidator.Validate)}");

            List<string> errorMessages = new List<string>();

            var employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery());
            if (!employees.Any(e => e.Id == model.EmployeeId))
            {
                errorMessages.Add($"Employee with id {model.EmployeeId} does not exists");
            }

            _logger.LogInformation($"End class {nameof(DeleteEmployeeRequestModelValidator)} and method {nameof(DeleteEmployeeRequestModelValidator.Validate)}");
            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }
        }
    }
}
