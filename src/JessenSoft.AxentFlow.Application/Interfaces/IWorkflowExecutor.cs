namespace JessenSoft.AxentFlow.Application.Interfaces
{
    /// <summary>
    /// Executes workflows by running their steps in order.
    /// </summary>
    public interface IWorkflowExecutor
    {
        /// <summary>
        /// Executes a workflow definition including all of its steps.
        /// </summary>
        Task ExecuteAsync(Guid workflowDefinitionId);
    }
}