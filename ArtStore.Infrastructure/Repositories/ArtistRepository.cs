using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ArtStoreDbContext _context;
        public ArtistRepository(ArtStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }
        public async Task<Artist?> GetByIdAsync(Guid id)
        {
            return await _context.Artists.Include(p => p.Products).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

    }
}
