using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetAllEmployees;
using Microsoft.Extensions.Logging;
using Services.Models.EmployeeParameterModels.RequestModels;

namespace Services.Validations
{
    public class DeleteEmployeeParameterRequestModelValidator : IValidation<DeleteEmployeeParameterRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllEmployeesQuery, IList<Employee>> _employeesQueryHandler;

        public DeleteEmployeeParameterRequestModelValidator(
            ILogger<DeleteEmployeeParameterRequestModelValidator> logger,
            IQueryHandler<GetAllEmployeesQuery, IList<Employee>> employeesQueryHandler)
        {
            _logger = logger;
            _employeesQueryHandler = employeesQueryHandler;
        }

        public async Task Validate(DeleteEmployeeParameterRequestModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(DeleteEmployeeParameterRequestModelValidator)} and method {nameof(DeleteEmployeeParameterRequestModelValidator.Validate)}");

            List<string> errorMessages = new List<string>();

            var employees = await _employeesQueryHandler.HandleAsync(new GetAllEmployeesQuery());
            if (!employees.Any(e => !e.Parameters.Any(p => p.Id == model.EmployeeParameterId)))
            {
                errorMessages.Add($"Employee parameter with id {model.EmployeeParameterId} does not exists");
            }

            _logger.LogInformation($"End class {nameof(DeleteEmployeeParameterRequestModelValidator)} and method {nameof(DeleteEmployeeParameterRequestModelValidator.Validate)}");
            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                throw new NotFoundException(message);
            }
        }
    }
}
