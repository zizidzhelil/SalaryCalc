using Common.LogResources;
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
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.InsertingItem, nameof(Parameter)));
            Parameter parameter = await _context.Parameters.SingleOrDefaultAsync(p => p.Year == command.Year, cancellationToken: cancellationToken);

            if (parameter != null)
            {
                parameter.MinThreshold = command.MinThreshold;
                parameter.TotalIncomeTaxPercentage = command.TotalIncomeTaxPercentage;
                parameter.HealthAndSocialInsurancePercentage = command.HealthAndSocialInsurancePercentage;
                parameter.MaxThreshold = command.MaxThreshold;

                _logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(Parameter)));
                _context.Update(parameter);

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(Parameter), command.Year));
            }
        }
    }
}
