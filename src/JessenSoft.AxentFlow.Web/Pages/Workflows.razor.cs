using JessenSoft.AxentFlow.Application.Interfaces;
using JessenSoft.AxentFlow.Core.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JessenSoft.AxentFlow.Web.Pages
{
    public partial class Workflows : ComponentBase
    {
        [Inject] private IWorkflowService WorkflowService { get; set; } = default!;
        [Inject] protected NavigationManager Navigation { get; set; } = default!;

        protected string SearchText { get; set; } = string.Empty;

        protected List<WorkflowDefinition> WorkflowList = new();

        protected IEnumerable<WorkflowDefinition> FilteredWorkflows =>
        string.IsNullOrWhiteSpace(SearchText)
            ? WorkflowList
            : WorkflowList.Where(w =>
                w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                (w.Description ?? "").Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        protected override async Task OnInitializedAsync()
        {
            WorkflowList = (await WorkflowService.GetAllAsync())
                .Where(w => w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        protected void CreateNewWorkflow()
        {
            Navigation.NavigateTo("/workflows/create");
        }
    }
}