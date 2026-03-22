using ArtStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure
{
    public class ArtStoreDbContext : IdentityDbContext<User>
	{
        public ArtStoreDbContext(DbContextOptions<ArtStoreDbContext> options) : base(options)
        {
		}

        public DbSet<Product> Products { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtStoreDbContext).Assembly);

			base.OnModelCreating(modelBuilder);

			// Favorites art configuration (many-to-many)
			modelBuilder.Entity<User>()
				.HasMany(u => u.Favorites)
				.WithMany() 
				.UsingEntity(j => j.ToTable("UserFavorites"));
		}
	}
}
