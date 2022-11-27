using Core.Commands;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.UpdateParameter
{
    public class UpdateParameterCommandHandler : ICommandHandler<UpdateParameterCommand>
    {
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

        public UpdateParameterCommandHandler(ILogger<UpdateParameterCommandHandler> logger, SalaryCalcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task HandleAsync(UpdateParameterCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Begin class {nameof(UpdateParameterCommandHandler)} and method {nameof(UpdateParameterCommandHandler.HandleAsync)}");
            Parameter parameter = await _context.Parameters.SingleOrDefaultAsync(p => p.Year == command.Parameter.Year, cancellationToken: cancellationToken);

            if (parameter != null)
            {
                parameter.MinThreshold = command.Parameter.MinThreshold;
                parameter.TotalIncomeTaxPercentage = command.Parameter.TotalIncomeTaxPercentage;
                parameter.HealthAndSocialInsurancePercentage = command.Parameter.HealthAndSocialInsurancePercentage;
                parameter.MaxThreshold = command.Parameter.MaxThreshold;

                _logger.LogInformation($"{nameof(parameter)} is not null in class {nameof(UpdateParameterCommandHandler)} and method {nameof(UpdateParameterCommandHandler.HandleAsync)}");
                _context.Update(parameter);

                await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"End class {nameof(UpdateParameterCommandHandler)} and method {nameof(UpdateParameterCommandHandler.HandleAsync)}");
            }
            else
            {
                _logger.LogInformation($"{nameof(parameter)} is null in class {nameof(UpdateParameterCommandHandler)} and method {nameof(UpdateParameterCommandHandler.HandleAsync)}");
            }
        }
    }
}
