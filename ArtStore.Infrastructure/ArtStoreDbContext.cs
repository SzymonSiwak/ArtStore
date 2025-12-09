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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtStoreDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}
	}
}
