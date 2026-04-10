using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);

        // For user friendly URLs
        Task<Category?> GetBySlugAsync(string slug);

        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}