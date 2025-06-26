using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySampleApp.Domain.Interfaces;
using MySampleApp.Domain.Options;
using MySampleApp.Infrastructure.Data;
using MySampleApp.Infrastructure.Repositories;
using MySampleApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<MySampleAppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IExternalProductRepository, ExternalProductRepository>();
            services.AddHttpClient<FakeStoreHttpClientService>();
            return services;
        }
    }
}
