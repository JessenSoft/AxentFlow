using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using JessenSoft.AxentFlow.Core.Enums;

namespace JessenSoft.AxentFlow.Core.Models
{
    /// <summary>
    /// Represents an individual executable step within a workflow.
    /// </summary>
    public class WorkflowStep
    {
        /// <summary>
        /// Unique identifier of the step.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the parent workflow definition.
        /// </summary>
        public Guid WorkflowDefinitionId { get; set; }

        /// <summary>
        /// Name of the step.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Execution order of the step within the workflow.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Type of step (e.g., HttpRequest, SqlCommand).
        /// </summary>
        public WorkflowStepType StepType { get; set; }

        /// <summary>
        /// Serialized list of parameters as JSON.
        /// </summary>
        public string? ParametersJson { get; set; }

        /// <summary>
        /// Deserialized list of parameters (not mapped to DB).
        /// </summary>
        [NotMapped]
        public List<WorkflowParameter> Parameters
        {
            get => string.IsNullOrWhiteSpace(ParametersJson)
                ? new List<WorkflowParameter>()
                : JsonSerializer.Deserialize<List<WorkflowParameter>>(ParametersJson!) ?? new();
            set => ParametersJson = JsonSerializer.Serialize(value);
        }

        /// <summary>
        /// Navigation property to the parent workflow definition.
        /// </summary>
        public WorkflowDefinition? WorkflowDefinition { get; set; }
    }
}