using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(string userId);
        Task AddAsync(Cart cart);
        Task SaveChangesAsync();

	}
}
