
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JessenSoft.AxentFlow.Web.Pages
{
    public partial class Workflows : ComponentBase
    {
        [Inject] protected NavigationManager Navigation { get; set; } = default!;

        protected string SearchText { get; set; } = string.Empty;

        protected List<WorkflowListItem> WorkflowList = new()
    {
        new("ETL Job Import", "Lädt Auftragsdaten via HTTP", true),
        new("Rechnungserstellung", "Erzeugt ZUGFeRD-Dokumente", false),
        new("Benachrichtigung", "Sendet E-Mail bei neuen Events", true)
    };

        protected IEnumerable<WorkflowListItem> FilteredWorkflows =>
            string.IsNullOrWhiteSpace(SearchText)
                ? WorkflowList
                : WorkflowList.Where(w => w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        protected void CreateNewWorkflow()
        {
            Navigation.NavigateTo("/workflows/create");
        }

        public record WorkflowListItem(string Name, string Description, bool IsActive);
    }
}
