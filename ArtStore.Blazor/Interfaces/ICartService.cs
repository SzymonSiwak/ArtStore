using System.Net.Http;
using System.Net.Http.Headers;
using ArtStore.Blazor.Services;
using ArtStore.Shared.DTOs;

namespace ArtStore.Blazor.Interfaces
{
    public interface ICartService
    {
		Task AddToCart(Guid productId, int quantity);
		Task<CartDto?> GetCart();
		Task RemoveFromCart(Guid productId);
	}
}
