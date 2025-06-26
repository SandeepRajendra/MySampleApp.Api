using MySampleApp.Application;
using MySampleApp.Domain;
using MySampleApp.Infrastructure;

namespace MySampleApp.Api
{
    public static class ApiDI
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddDomainDI(configuration);
            return services;
        }
    }
}
