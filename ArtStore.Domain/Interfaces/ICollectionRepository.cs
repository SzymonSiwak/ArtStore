using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<Collection>> GetAllAsync();
        Task<Collection?> GetByIdAsync(Guid id);

        // For SEO-friendly URLs
        Task<Collection?> GetBySlugAsync(string slug);

        Task AddAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task DeleteAsync(Collection collection);
    }
}
