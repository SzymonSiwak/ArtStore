using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtStore.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

			// Configure Money value object as owned entity
			builder.OwnsOne(p => p.Price, priceBuilder =>
            {
				priceBuilder.Property(m => m.Amount)
                     .HasColumnName("PriceAmount")
                     .HasColumnType("decimal(18,2)")
					 .IsRequired();

				priceBuilder.Property(m => m.Currency)
                     .HasColumnName("PriceCurrency")
                     .HasMaxLength(3)
                     .IsRequired();
            });
			
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Category)
                   .HasConversion<string>();

            builder.HasOne(p => p.Artist)
                   .WithMany(a => a.Products)
                   .HasForeignKey(p => p.ArtistId);
		}
	}
}
