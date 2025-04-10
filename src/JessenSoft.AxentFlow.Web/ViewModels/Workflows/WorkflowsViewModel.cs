using JessenSoft.AxentFlow.Application.Interfaces;
using JessenSoft.AxentFlow.Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Reactive.Linq;

namespace JessenSoft.AxentFlow.Web.ViewModels.Workflows
{
    /// <summary>
    /// ViewModel für die Übersicht aller Workflows.
    /// Nutzt direkt das Domainmodell WorkflowDefinition.
    /// </summary>
    public class WorkflowsViewModel : ReactiveObject
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowsViewModel(IWorkflowService workflowService)
        {
            _workflowService = workflowService;

            LoadCommand = ReactiveCommand.CreateFromTask(LoadAsync);
            SearchText = string.Empty;

            Observable
                .CombineLatest(
                    this.WhenAnyValue(x => x.SearchText),
                    this.WhenAnyValue(x => x.AllWorkflows).StartWith(new List<WorkflowDefinition>()),
                    (_, __) => Unit.Default
                )
                .Select(_ => Filter())
                .ToPropertyEx(this, x => x.FilteredWorkflows);
        }

        [Reactive]
        public string SearchText { get; set; } = string.Empty;

        [Reactive] 
        public List<WorkflowDefinition> AllWorkflows { get; set; } = new();

        [ObservableAsProperty] 
        public IEnumerable<WorkflowDefinition> FilteredWorkflows { get; } = Enumerable.Empty<WorkflowDefinition>();

        public ReactiveCommand<Unit, Unit> LoadCommand { get; }

        private async Task LoadAsync()
        {
            AllWorkflows = (await _workflowService.GetAllAsync()).ToList();
        }

        private IEnumerable<WorkflowDefinition> Filter()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return AllWorkflows;

            return AllWorkflows.Where(w =>
                w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                (w.Description?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ?? false));
        }
    }
}