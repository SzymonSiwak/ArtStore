using ArtStore.Application.Common.Interfaces;
using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using ArtStore.Infrastructure.Repositories;
using ArtStore.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ArtStore.Infrastructure.Persistence.Repositories;

namespace ArtStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<ArtStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Identity and TokenService registration
            services.AddIdentityCore<User>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ArtStoreDbContext>()
				.AddSignInManager<SignInManager<User>>()
				.AddDefaultTokenProviders();

			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthService, AuthService>();

			// Register repositories
			services.AddScoped<ICartRepository, CartRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            // Add other repositories as needed
            return services;
        }
    }
}
