namespace JessenSoft.AxentFlow.Core.Models
{
    /// <summary>
    /// Represents a key-value parameter used within a workflow step.
    /// </summary>
    public class WorkflowParameter
    {
        /// <summary>
        /// Name of the parameter.
        /// </summary>
        public string Key { get; set; } = default!;

        /// <summary>
        /// Value assigned to the parameter.
        /// </summary>
        public string Value { get; set; } = default!;
    }
}