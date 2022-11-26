using Common.LogResources;
using Core.Commands;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.InsertParameter
{
	public class InsertParameterCommandHandler : ICommandHandler<InsertParameterCommand>
	{
        private readonly ILogger _logger;
        private readonly SalaryCalcContext _context;

		public InsertParameterCommandHandler(ILogger<InsertParameterCommandHandler> logger, SalaryCalcContext context)
		{
            _logger = logger;
            _context = context;
		}

		public async Task HandleAsync(InsertParameterCommand command, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation(LogEvents.InsertingItem, string.Format(LogMessageResources.InsertingItem, nameof(Parameter)));
			Parameter parameter = new Parameter()
			{
				Year = command.Year,
				MinThreshold = command.MinThreshold,
				MaxThreshold = command.MaxThreshold,
				TotalIncomeTaxPercentage = command.TotalIncomeTaxPercentage,
				HealthAndSocialInsurancePercentage = command.HealthAndSocialInsurancePercentage
			};

			await _context.AddAsync(parameter, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			_logger.LogInformation(LogEvents.InsertedItem, string.Format(LogMessageResources.InsertedItem, nameof(Parameter)));
		}
	}
}
