using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetParameters;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadParameterEffect : Effect<LoadParameterAction>
    {
        private readonly IQueryHandler<GetParametersQuery, ParameterModel> _getParametersQuery;

        public LoadParameterEffect(IQueryHandler<GetParametersQuery, ParameterModel> getParametersQuery)
        {
            _getParametersQuery= getParametersQuery;
        }

        public override async Task HandleAsync(LoadParameterAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            ParameterModel parameter = await _getParametersQuery.HandleAsync(new GetParametersQuery(action.Year));
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetParametersAction(parameter));
        }
    }
}
