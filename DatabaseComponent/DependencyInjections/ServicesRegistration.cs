using DatabaseComponent.Interfaces;
using DatabaseComponent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExportingComponent.DependencyInjection
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingContext, BookingContext>();
            services.AddDbContext<BookingContext>(options => options.UseSqlServer("Server=dbs-oa-dk2.database.windows.net;Database=db-oa-dk2;Initial Catalog=db-oa-dk2;User ID=admin-oa-dk2;Password=oceanicFlyAway16;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Integrated Security=False"));
            return services;
        }

    }
}