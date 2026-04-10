using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface IUserRepository
    {
		Task<User?> GetByIdWithFavoritesAsync(string userId);
		Task UpdateAsync(User user);
	}
}
