using ArtStore.Shared.DTOs;

namespace ArtStore.Blazor.Interfaces
{
    public interface ICartService
    {
		Task AddToCart(Guid productId, int quantity);
		Task<CartDto?> GetCart();
	}
}
