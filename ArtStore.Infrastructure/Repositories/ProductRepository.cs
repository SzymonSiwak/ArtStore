using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using ArtStore.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ArtStoreDbContext _context;

        public ProductRepository(ArtStoreDbContext context)
        {
            _context = context;
		}

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .FirstOrDefaultAsync(p => p.Id == id);
		}

        public async Task<IEnumerable<Product>> GetBestsellersAsync(int count)
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .Where(p => p.IsBestseller)
                                 .Take(count)
                                 .ToListAsync();
		}

        public async Task<IEnumerable<Product>> GetNewArrivalsAsync(int count)
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .OrderByDescending(p => p.CreatedAt)
                                 .Take(count)
                                 .ToListAsync();
		}

        public async Task<IEnumerable<Product>> GetByCategoryAsync(Category category)
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .Where(p => p.Category == category)
                                 .ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterDto filter)
        {
            var query = _context.Products
                                .Include(p => p.Artist)
                                .AsQueryable();

            switch(filter.CollectionName?.ToLower())
            {
                case "bestsellers":
                    query = query.Where(p => p.IsBestseller);
                    break;

                case "new-arrivals":
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;

                case "living":
                    query = query.Where(p => p.Category == Category.Living_Accessories);
                    break;

                case "stationary":
                    query = query.Where(p => p.Category == Category.Stationary);
                    break;
            }

			if (filter.MinPrice.HasValue)
				query = query.Where(p => p.Price.Amount >= filter.MinPrice.Value);

			if (filter.MaxPrice.HasValue)
				query = query.Where(p => p.Price.Amount <= filter.MaxPrice.Value);

			if (filter.FrameType.HasValue)
				query = query.Where(p => p.Frame == filter.FrameType.Value);

			if (filter.SpecificCategory.HasValue)
				query = query.Where(p => p.Category == filter.SpecificCategory.Value);

			return await query.ToListAsync();
		}


		public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
		}

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
		}

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
		}
	}
}
