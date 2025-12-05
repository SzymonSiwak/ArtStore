using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Enums;
using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
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

        public async Task<IEnumerable<Product>> GetBestSellersAsync(int count)
        {
            return await _context.Products
                                 .Include(p => p.Artist)
                                 .Where(p => p.IsBestSeller)
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
