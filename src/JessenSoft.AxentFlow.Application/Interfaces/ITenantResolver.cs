namespace JessenSoft.AxentFlow.Application.Interfaces
{
    /// <summary>
    /// Resolves the current tenant based on context (e.g., subdomain).
    /// </summary>
    public interface ITenantResolver
    {
        /// <summary>
        /// Returns the current tenant identifier.
        /// </summary>
        string GetCurrentTenantId();
    }
}