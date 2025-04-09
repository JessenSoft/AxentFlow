using JessenSoft.AxentFlow.Core.Models;

namespace JessenSoft.AxentFlow.Application.Interfaces
{
    /// <summary>
    /// Provides operations to manage workflow definitions.
    /// </summary>
    public interface IWorkflowService
    {
        /// <summary>
        /// Retrieves all workflow definitions.
        /// </summary>
        Task<IEnumerable<WorkflowDefinition>> GetAllAsync();

        /// <summary>
        /// Retrieves a workflow by ID.
        /// </summary>
        Task<WorkflowDefinition?> GetByIdAsync(Guid id);

        /// <summary>
        /// Creates a new workflow definition.
        /// </summary>
        Task<WorkflowDefinition> CreateAsync(WorkflowDefinition definition);

        /// <summary>
        /// Updates an existing workflow definition.
        /// </summary>
        Task UpdateAsync(WorkflowDefinition definition);

        /// <summary>
        /// Deletes a workflow definition by ID.
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}