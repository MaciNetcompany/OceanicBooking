
using DatabaseComponent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExportingComponent.DependencyInjection
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services)
        {

            services.AddDbContext<BookingContext>(options => options.UseSqlServer("server=dbs-oa-dk2.database.windows.net;database=db-oa-dk2;trusted_connection=true;"));
            return services;
        }

    }
}