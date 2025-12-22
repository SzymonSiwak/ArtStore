using ArtStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtStore.Infrastructure.Persistence.Configurations
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.HasKey(c => c.Id);

			// Id already generated in BaseEntity class
			builder.Property(c => c.Id).ValueGeneratedNever();

			builder.Property(c => c.UserId).IsRequired();
		}
	}

	public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
	{
		public void Configure(EntityTypeBuilder<CartItem> builder)
		{
			builder.HasKey(ci => ci.Id);

			builder.Property(ci => ci.Id).ValueGeneratedNever();

			builder.Property(ci => ci.Quantity).IsRequired();

			builder.HasOne(ci => ci.Product).WithMany().HasForeignKey(ci => ci.ProductId);
		}
	}
}