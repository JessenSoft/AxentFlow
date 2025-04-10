using JessenSoft.AxentFlow.Application.Interfaces;
using JessenSoft.AxentFlow.Core.Enums;
using JessenSoft.AxentFlow.Core.Models;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Reactive;

namespace JessenSoft.AxentFlow.Web.ViewModels.Workflows
{
    /// <summary>
    /// ViewModel zum Erstellen eines neuen Workflows.
    /// Kapselt Eingabedaten und SaveCommand.
    /// </summary>
    public class WorkflowCreateViewModel : ReactiveObject
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowCreateViewModel(IWorkflowService workflowService)
        {
            _workflowService = workflowService;

            var canSave = this.WhenAnyValue(x => x.Name, name => !string.IsNullOrWhiteSpace(name));

            SaveCommand = ReactiveCommand.CreateFromTask(ExecuteSaveAsync, canSave);

            canSave.ToPropertyEx(this, x => x.CanSave);
            SaveCommand.IsExecuting.ToPropertyEx(this, x => x.IsSaving);
        }

        [Reactive]
        public string Name { get; set; } = string.Empty;

        [Reactive]
        public string? Description { get; set; }

        [Reactive]
        public WorkflowStatus Status { get; set; } = WorkflowStatus.Draft;

        [ObservableAsProperty]
        public bool CanSave { get; }

        [ObservableAsProperty]
        public bool IsSaving { get; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        private async Task ExecuteSaveAsync()
        {
            var workflow = new WorkflowDefinition
            {
                Name = Name,
                Description = Description,
                Status = Status
            };

            await _workflowService.CreateAsync(workflow);
        }
    }
}