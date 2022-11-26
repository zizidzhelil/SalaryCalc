using Core.Models;
using Core.Queries;
using Fluxor;
using SalaryCalcWeb.Store.Dom.Actions;
using SalaryCalcWeb.Store.Salaries.Actions;
using Services.Queries.GetSalary;

namespace SalaryCalcWeb.Store.Salaries.Effects
{
    public class LoadNetSalaryEffect : Effect<LoadNetSalaryAction>
    {
        private readonly IQueryHandler<GetSalaryQuery, SalaryModel> _getSalaryQuery;

        public LoadNetSalaryEffect(IQueryHandler<GetSalaryQuery, SalaryModel> getSalaryQuery)
        {
            _getSalaryQuery = getSalaryQuery;
        }

        public override async Task HandleAsync(LoadNetSalaryAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            SalaryModel salary = await _getSalaryQuery.HandleAsync(new GetSalaryQuery(action.ToSalaryRequestModel()));
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetSalaryAction(salary));
        }
    }
}
