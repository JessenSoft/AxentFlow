namespace JessenSoft.AxentFlow.Core.Enums
{
    /// <summary>
    /// Describes the type of operation a workflow step performs.
    /// </summary>
    public enum WorkflowStepType
    {
        /// <summary>Sends an HTTP request to a given endpoint.</summary>
        HttpRequest,

        /// <summary>Executes a SQL command against a configured database.</summary>
        SqlCommand,

        /// <summary>Sends an email using configured mail settings.</summary>
        SendEmail,

        /// <summary>Waits for a configured delay period.</summary>
        Delay,

        /// <summary>Custom step defined by plugins or user logic.</summary>
        Custom
    }
}