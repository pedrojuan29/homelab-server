using Homelab.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homelab.Data.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgreSqlPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HomelabContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
