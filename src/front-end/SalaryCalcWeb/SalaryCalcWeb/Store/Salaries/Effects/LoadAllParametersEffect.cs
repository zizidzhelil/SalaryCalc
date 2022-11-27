using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetAllParameters;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadAllParametersEffect : Effect<LoadAllParametersAction>
    {
        private readonly IQueryHandler<GetAllParametersQuery, IList<ParameterModel>> _getAllParametersQuery;

        public LoadAllParametersEffect(IQueryHandler<GetAllParametersQuery, IList<ParameterModel>> getAllParametersQuery)
        {
            _getAllParametersQuery = getAllParametersQuery;
        }

        public override async Task HandleAsync(LoadAllParametersAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            IList<ParameterModel> parameters = await _getAllParametersQuery.HandleAsync(new GetAllParametersQuery());
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetAllParametersAction(parameters));
        }
    }
}
