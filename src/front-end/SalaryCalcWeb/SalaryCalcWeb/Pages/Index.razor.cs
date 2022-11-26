using Fluxor;
using Microsoft.AspNetCore.Components;
using SalaryCalcWeb.Store.Dom;

namespace SalaryCalcWeb.Pages
{
    public partial class Index
    {
        [Inject] public IState<DomState> State { get; set; }

        protected override Task OnInitializedAsync()
        {


            return base.OnInitializedAsync();
        }
    }
}
