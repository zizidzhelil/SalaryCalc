using Core.Commands;
using Core.Entities;

namespace DAL.Commands.InsertParameter
{
	public class InsertParameterCommandHandler : ICommandHandler<InsertParameterCommand>
	{
		private readonly SalaryCalcContext _context;

		public InsertParameterCommandHandler(SalaryCalcContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(InsertParameterCommand command, CancellationToken cancellationToken = default)
		{
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
		}
	}
}
