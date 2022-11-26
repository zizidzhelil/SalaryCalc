using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Dom;

namespace SalaryCalcWeb.Shared
{
    public partial class Header
    {
        [Inject] public IState<DomState> DomState { get; set; }
    }
}
