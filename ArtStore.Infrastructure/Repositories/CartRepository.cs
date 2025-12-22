using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ArtStoreDbContext _context;

        public CartRepository(ArtStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
		}

        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
		}

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
		}
	}
}
