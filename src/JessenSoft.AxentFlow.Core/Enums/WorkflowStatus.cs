namespace JessenSoft.AxentFlow.Core.Enums
{
    /// <summary>
    /// Represents the lifecycle status of a workflow definition.
    /// </summary>
    public enum WorkflowStatus
    {
        /// <summary>Workflow is being drafted and not yet active.</summary>
        Draft,

        /// <summary>Workflow is active and may be executed.</summary>
        Active,

        /// <summary>Workflow is inactive but remains available.</summary>
        Inactive,

        /// <summary>Workflow is archived and read-only.</summary>
        Archived
    }
}