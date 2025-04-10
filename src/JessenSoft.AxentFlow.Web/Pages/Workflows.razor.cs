using JessenSoft.AxentFlow.Web.ViewModels.Workflows;
using Microsoft.AspNetCore.Components;
using System.Reactive.Linq;

namespace JessenSoft.AxentFlow.Web.Pages
{
    /// <summary>
    /// Code-behind der Workflows-Seite.
    /// </summary>
    public partial class Workflows : ComponentBase
    {
        [Inject] public WorkflowsViewModel Vm { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await Vm.LoadCommand.Execute();
        }
    }
}