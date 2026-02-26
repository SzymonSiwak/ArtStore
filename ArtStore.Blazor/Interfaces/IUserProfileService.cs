using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDto?> GetProfile();
        Task ToggleFavorite(Guid productId);
        bool IsFavorite(Guid productId);
		event Action? OnChange;
	}
}
