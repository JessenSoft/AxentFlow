using JessenSoft.AxentFlow.Application.Interfaces;
using JessenSoft.AxentFlow.Web.ViewModels.Workflows;
using Microsoft.AspNetCore.Components;

namespace JessenSoft.AxentFlow.Web.Pages
{
    /// <summary>
    /// Page für das Erstellen eines neuen Workflows.
    /// </summary>
    public partial class WorkflowsCreate : ComponentBase
    {
        [Inject] private IWorkflowService WorkflowService { get; set; } = default!;
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        protected WorkflowCreateViewModel Vm = default!;

        protected override void OnInitialized()
        {
            Vm = new WorkflowCreateViewModel(WorkflowService);

            // Navigation nach erfolgreichem Speichern
            Vm.SaveCommand.Subscribe(_ =>
            {
                Navigation.NavigateTo("/workflows");
            });
        }
    }
}
