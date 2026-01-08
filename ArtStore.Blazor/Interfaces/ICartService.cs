namespace ArtStore.Blazor.Interfaces
{
    public interface ICartService
    {
		Task AddToCart(Guid productId, int quantity);
	}
}
