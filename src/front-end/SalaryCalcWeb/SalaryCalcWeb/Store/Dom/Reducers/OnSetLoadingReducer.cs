using Fluxor;
using SalaryCalcWeb.Store.Dom;
using SalaryCalcWeb.Store.Dom.Actions;

namespace SalaryCalcWeb.Store.Dom.Reducers
{
    public class OnSetLoadingReducer : Reducer<DomState, SetLoadingAction>
    {
        public override DomState Reduce(DomState state, SetLoadingAction action)
        {
            return new DomState
            {
                IsLoading = action.IsLoading,
                ErrorMessage = state.ErrorMessage,
            };
        }
    }
}
