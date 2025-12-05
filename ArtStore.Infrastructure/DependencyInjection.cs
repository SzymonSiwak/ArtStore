using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Interfaces;
using ArtStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<ArtStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            // Add other repositories as needed
            return services;
		}
	}
}
