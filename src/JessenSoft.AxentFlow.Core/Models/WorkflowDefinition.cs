using JessenSoft.AxentFlow.Core.Enums;

namespace JessenSoft.AxentFlow.Core.Models
{
    /// <summary>
    /// Represents a reusable workflow definition containing ordered steps.
    /// </summary>
    public class WorkflowDefinition
    {
        /// <summary>
        /// Unique identifier of the workflow.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Display name of the workflow.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Optional description of the workflow.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Status of the workflow (Draft, Active, etc.).
        /// </summary>
        public WorkflowStatus Status { get; set; } = WorkflowStatus.Draft;

        /// <summary>
        /// Collection of steps that make up the workflow.
        /// </summary>
        public ICollection<WorkflowStep> Steps { get; set; } = new List<WorkflowStep>();

        /// <summary>
        /// UTC timestamp when the workflow was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// UTC timestamp when the workflow was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}