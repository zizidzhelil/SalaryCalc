using Core.Commands;
using Core.Entities;

namespace DAL.Commands.UpdateParameter
{
	public class UpdateParameterCommandHandler : ICommandHandler<UpdateParameterCommand>
	{
		private readonly SalaryCalcContext _context;

		public UpdateParameterCommandHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(UpdateParameterCommand command, CancellationToken cancellationToken = default)
		{
			Parameter parameter = await _context.Parameters.FindAsync(command.Year);
			
			if (parameter != null)
			{
				parameter.MinThreshold = command.MinThreshold;
				parameter.TotalIncomeTaxPercentage = command.TotalIncomeTaxPercentage;
				parameter.HealthAndSocialInsurancePercentage = command.HealthAndSocialInsurancePercentage;
				parameter.MaxThreshold = command.MaxThreshold;
			}

			_context.Update(parameter);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
} 
