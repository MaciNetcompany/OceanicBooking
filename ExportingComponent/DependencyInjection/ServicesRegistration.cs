using ExportingComponent.Interfaces;
using ExportingComponent.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExportingComponent.DependencyInjection
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddCSVExporter(this IServiceCollection services)
        {
            services.AddScoped<ICSVExporter, CSVExporter>();

            return services;
        }
    }
}