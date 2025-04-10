using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JessenSoft.AxentFlow.Infrastructure.Extensions
{
    /// <summary>
    /// Hilfsklasse zur automatischen Service-Registrierung.
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Registriert alle ViewModels mit dem Suffix "ViewModel" aus der angegebenen Assembly als Scoped-Services.
        /// </summary>
        /// <param name="services">Die ServiceCollection.</param>
        /// <param name="assembly">Die Assembly, in der ViewModels gesucht werden.</param>
        /// <returns>Die aktualisierte ServiceCollection.</returns>
        public static IServiceCollection AddViewModels(this IServiceCollection services, Assembly assembly)
        {
            var viewModelTypes = assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("ViewModel"));

            foreach (var type in viewModelTypes)
            {
                services.AddScoped(type);
            }

            return services;
        }
    }
}