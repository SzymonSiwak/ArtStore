using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ArtStoreDbContext _context;

        public CategoryRepository(ArtStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetBySlugAsync(string slug)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Slug.ToLower() == slug.ToLower());
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}