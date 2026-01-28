using ArtStore.Domain.Entities;
using ArtStore.Shared.Enums;
using ArtStore.Domain.ValueObjects;

namespace ArtStore.Infrastructure
{
	public static class ArtStoreDbContextSeed
	{
		public static async Task SeedAsync(ArtStoreDbContext context)
		{
			if (context.Artists.Any())
			{
				return;
			}

			var artist1 = new Artist
			{
				Name = "Vincent van Gogh",
				Bio = "Dutch post-impressionist painter.",
				AvatarUrl = "data:image/jpeg;base64,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"
			};

			var artist2 = new Artist
			{
				Name = "Claude Monet",
				Bio = "French painter, one of the founders of Impressionism.",
				AvatarUrl = "data:image/jpeg;base64,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"
			};

			var artist3 = new Artist
			{
				Name = "Poster Creator",
				Bio = "Creator of various posters available in the store.",
				AvatarUrl = "images/poster-creator.jpg"
			};

			var artist4 = new Artist
			{
				Name = "Paintings creator",
				Bio = "Creator of various paintings available in the store.",
				AvatarUrl = "images/poster-creator-2.jpg"
			};

			await context.Artists.AddRangeAsync(artist1, artist2);

			await context.SaveChangesAsync();


			var products = new List<Product>
			{

                new Product
				{
					Name = "Starry Night",
					Description = "Famous star painting",
					Dimensions = "73x92 cm",
					ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRYRHg2ZPNoxbhAY8xxyaCVBeKirNIVHGP_g&s",
					Price = new Money(12000, "USD"),
					Category = Category.Living_Accessories,
					IsBestseller = true, 
                    ArtistId = artist1.Id,
					Frame = FrameType.Gold, 
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},
				new Product
				{
					Name = "Sunflowers",
					Description = "Bright and fresh flowers.",
					Dimensions = "92x73 cm",
					ImageUrl = "https://images.photowall.com/products/44235/gogh-vincent-van-sunflowers.jpg?h=699&q=85",
					Price = new Money(5000, "USD"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist1.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddMonths(-5)
				},

                new Product
				{
					Name = "Water Lilies",
					Description = "Calm water with lilies.",
					Dimensions = "200x200 cm",
					ImageUrl = "https://1.bonami.pl/images/fit-crop-fill/4c/2d/4c2dc61d8bc05cf8f887154636d6bd09a98f8e60-1000x1000.jpeg",
					Price = new Money(8500, "USD"),
					Category = Category.Stationary,
					IsBestseller = true, 
                    ArtistId = artist2.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},
				new Product
				{
					Name = "Impression, Sunrise",
					Description = "A painting from which impressionism can be applied.",
					Dimensions = "48x63 cm",
					ImageUrl = "https://placehold.co/600x400",
					Price = new Money(9000, "USD"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist2.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},
                 
                // for test purposes
                new Product
				{
					Name = "Abstract #5",
					Description = "Nowoczesna sztuka.",
					Dimensions = "50x50 cm",
					ImageUrl = "https://placehold.co/600x400",
					Price = new Money(300, "USD"),
					Category = Category.Other,
					IsBestseller = true,
					ArtistId = artist1.Id
				},

				// Sample data from wwwroot/images
				new Product
				{
					Name = "Bangkok",
					Description = "Poster from bangkok",
					Dimensions = "54x27 cm",
					ImageUrl = "images/bangkok.jpg",
					Price = new Money(18, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},

				new Product
				{
					Name = "Bathtub",
					Description = "Bathtub poster",
					Dimensions = "56x28 cm",
					ImageUrl = "images/bathtub.jpg",
					Price = new Money(21, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-5)
				},

				new Product
				{
					Name = "Beach",
					Description = "Poster from beach",
					Dimensions = "62x27 cm",
					ImageUrl = "images/beach.jpg",
					Price = new Money(15, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},

				new Product
				{
					Name = "Binoculars",
					Description = "Binoculars poster",
					Dimensions = "64x28 cm",
					ImageUrl = "images/binoculars.jpg",
					Price = new Money(25, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-4)
				},

				new Product
				{
					Name = "Botanical lover",
					Description = "Binoculars-lover poster",
					Dimensions = "54x26 cm",
					ImageUrl = "images/botanical-lover.jpg",
					Price = new Money(22, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-4)
				},

				new Product
				{
					Name = "Breakfast",
					Description = "Breakfast painting",
					Dimensions = "74x38 cm",
					ImageUrl = "images/breakfast.jpg",
					Price = new Money(114, "EUR"),
					Category = Category.Other,
					IsBestseller = false,
					ArtistId = artist4.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Cheers!",
					Description = "Cheers! poster",
					Dimensions = "54x28 cm",
					ImageUrl = "images/cheers.jpg",
					Price = new Money(14, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Cherry",
					Description = "Cherry painting",
					Dimensions = "174x138 cm",
					ImageUrl = "images/cherry.jpg",
					Price = new Money(314, "EUR"),
					Category = Category.Other,
					IsBestseller = true,
					ArtistId = artist4.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-7)
				},

				new Product
				{
					Name = "Couch",
					Description = "Couch poster",
					Dimensions = "34x18 cm",
					ImageUrl = "images/couch.jpg",
					Price = new Money(4, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Eggs",
					Description = "eggs painting",
					Dimensions = "174x88 cm",
					ImageUrl = "images/eggs.jpg",
					Price = new Money(104, "EUR"),
					Category = Category.Other,
					IsBestseller = false,
					ArtistId = artist4.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Eggs2",
					Description = "eggs poster, based on Eggs painting",
					Dimensions = "38x18 cm",
					ImageUrl = "images/eggs-2.jpg",
					Price = new Money(10, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Eleitas",
					Description = "Eleitas painting",
					Dimensions = "63x38 cm",
					ImageUrl = "images/eleitas.jpg",
					Price = new Money(126, "EUR"),
					Category = Category.Other,
					IsBestseller = false,
					ArtistId = artist4.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Feeling Spritzy",
					Description = "Feeling Spritzy poster",
					Dimensions = "74x88 cm",
					ImageUrl = "images/feeling-spritzy.jpg",
					Price = new Money(21, "EUR"),
					Category = Category.Stationary,
					IsBestseller = true,
					ArtistId = artist4.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-6)
				},

				new Product
				{
					Name = "Flower Head",
					Description = "Flower Head poster",
					Dimensions = "54x28 cm",
					ImageUrl = "images/flower-head.jpg",
					Price = new Money(21, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Flowers",
					Description = "flowers painting",
					Dimensions = "100x48 cm",
					ImageUrl = "images/flowers-2.jpg",
					Price = new Money(124, "EUR"),
					Category = Category.Other,
					IsBestseller = false,
					ArtistId = artist4.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Full of Shit",
					Description = "full of shit poster",
					Dimensions = "44x28 cm",
					ImageUrl = "images/full-of-shit.jpg",
					Price = new Money(10, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Green Image",
					Description = "green image poster",
					Dimensions = "54x28 cm",
					ImageUrl = "images/green-image.jpg",
					Price = new Money(15, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Greetings",
					Description = "eggs painting",
					Dimensions = "74x48 cm",
					ImageUrl = "images/greetings.jpg",
					Price = new Money(24, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Junijs",
					Description = "Junijs poster",
					Dimensions = "44x28 cm",
					ImageUrl = "images/junijs.jpg",
					Price = new Money(34, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Lighthouse",
					Description = "Lighthouse poster",
					Dimensions = "53x38 cm",
					ImageUrl = "images/lighthouse.jpg",
					Price = new Money(44, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-3)
				},

				new Product
				{
					Name = "Lobster",
					Description = "Lobster poster",
					Dimensions = "68x34 cm",
					ImageUrl = "images/lobster.jpg",
					Price = new Money(34, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "You are my lobster!",
					Description = "Very super sweet Lobster poster",
					Dimensions = "47x34 cm",
					ImageUrl = "images/lobster-6.jpg",
					Price = new Money(24, "EUR"),
					Category = Category.Stationary,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddDays(-10)
				},

				new Product
				{
					Name = "Pink lobster",
					Description = "Very super sweet pink Lobster poster",
					Dimensions = "37x15 cm",
					ImageUrl = "images/lobster-8.jpg",
					Price = new Money(44, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddDays(-17)
				},

				new Product
				{
					Name = "Missed Call",
					Description = "Missed call poster",
					Dimensions = "37x15 cm",
					ImageUrl = "images/missed-call.jpg",
					Price = new Money(26, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddDays(-26)
				},

				new Product
				{
					Name = "Mug",
					Description = "Mug painting",
					Dimensions = "167x115 cm",
					ImageUrl = "images/lmug.jpg",
					Price = new Money(444, "EUR"),
					Category = Category.Other,
					IsBestseller = true,
					ArtistId = artist4.Id,
					Frame = FrameType.Wood,
					CreatedAt = DateTime.UtcNow.AddMonths(-5)
				},

				new Product
				{
					Name = "Noodles",
					Description = "Very super noodles poster",
					Dimensions = "37x15 cm",
					ImageUrl = "images/noodles.jpg",
					Price = new Money(34, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-17)
				},

				new Product
				{
					Name = "Notebooks",
					Description = "Very super extra power notebooks poster",
					Dimensions = "68x45 cm",
					ImageUrl = "images/notebooks.jpg",
					Price = new Money(24, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Oranges",
					Description = "Very super oranges poster",
					Dimensions = "48x25 cm",
					ImageUrl = "images/oranges.jpg",
					Price = new Money(24, "EUR"),
					Category = Category.Stationary,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-7)
				},

				new Product
				{
					Name = "Parasite",
					Description = "Super parasite poster",
					Dimensions = "68x35 cm",
					ImageUrl = "images/parasite.jpg",
					Price = new Money(34, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddMonths(-5)
				},

				new Product
				{
					Name = "Pool day",
					Description = "Very super pool day painting",
					Dimensions = "148x125 cm",
					ImageUrl = "images/pool-day.jpg",
					Price = new Money(124, "EUR"),
					Category = Category.Other,
					IsBestseller = true,
					ArtistId = artist4.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-7)
				},

				new Product
				{
					Name = "Smile",
					Description = "Very super smile poster",
					Dimensions = "68x35 cm",
					ImageUrl = "images/smile.jpg",
					Price = new Money(24, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow
				},

				new Product
				{
					Name = "Socks",
					Description = "Very super socks painting",
					Dimensions = "148x125 cm",
					ImageUrl = "images/pool-day.jpg",
					Price = new Money(124, "EUR"),
					Category = Category.Other,
					IsBestseller = false,
					ArtistId = artist4.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddMonths(-5)
				},

				new Product
				{
					Name = "Springs-flowers",
					Description = "Very super spring flowers poster",
					Dimensions = "58x35 cm",
					ImageUrl = "images/spring-flowers.jpg",
					Price = new Money(38, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.None,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "Tenis",
					Description = "Very super tenis poster",
					Dimensions = "48x15 cm",
					ImageUrl = "images/tennis.jpg",
					Price = new Money(12, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = true,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow.AddMonths(-4)
				},

				new Product
				{
					Name = "Woman",
					Description = "Super sweet woman poster",
					Dimensions = "38x15 cm",
					ImageUrl = "images/woman.jpg",
					Price = new Money(32, "EUR"),
					Category = Category.Stationary,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Gold,
					CreatedAt = DateTime.UtcNow.AddMonths(-2)
				},

				new Product
				{
					Name = "wo-tiles",
					Description = "Super sweet wotiles",
					Dimensions = "48x23 cm",
					ImageUrl = "images/wo-tiles.jpg",
					Price = new Money(27, "EUR"),
					Category = Category.Living_Accessories,
					IsBestseller = false,
					ArtistId = artist3.Id,
					Frame = FrameType.Metal,
					CreatedAt = DateTime.UtcNow
				}

			};

			await context.Products.AddRangeAsync(products);
			await context.SaveChangesAsync();
		}
	}
}