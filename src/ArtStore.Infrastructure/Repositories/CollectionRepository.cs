using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Persistence.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly ArtStoreDbContext _context;

        public CollectionRepository(ArtStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collection>> GetAllAsync()
        {
            return await _context.Collections
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Collection?> GetByIdAsync(Guid id)
        {
            return await _context.Collections
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Collection?> GetBySlugAsync(string slug)
        {
            return await _context.Collections
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Slug.ToLower() == slug.ToLower());
        }

        public async Task AddAsync(Collection collection)
        {
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection collection)
        {
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Collection collection)
        {
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
        }
    }
}
