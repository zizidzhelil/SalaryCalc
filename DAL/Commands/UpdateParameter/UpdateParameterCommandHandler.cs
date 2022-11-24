using Common.LogResources;
using Core.Commands;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace DAL.Commands.UpdateParameter
{
	public class UpdateParameterCommandHandler : ICommandHandler<UpdateParameterCommand>
	{
		private readonly SalaryCalcContext _context;
		private readonly ILogger _logger;

		public UpdateParameterCommandHandler(SalaryCalcContext context, ILogger<UpdateParameterCommandHandler> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task HandleAsync(UpdateParameterCommand command, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.InsertingItem, nameof(Parameter)));
			Parameter parameter = await _context.Parameters.FindAsync(command.Year);
			
			if (parameter != null)
			{
				parameter.MinThreshold = command.MinThreshold;
				parameter.TotalIncomeTaxPercentage = command.TotalIncomeTaxPercentage;
				parameter.HealthAndSocialInsurancePercentage = command.HealthAndSocialInsurancePercentage;
				parameter.MaxThreshold = command.MaxThreshold;
			}
			else
			{
				_logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(Parameter), command.Year));
			}

			_logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(Parameter)));
			_context.Update(parameter);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
} 
