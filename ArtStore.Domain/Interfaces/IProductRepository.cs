using ArtStore.Domain.Entities;
using ArtStore.Shared.Enums;

namespace ArtStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();

        //Methods for categories on main page
        Task<IEnumerable<Product>> GetBestsellersAsync(int count);
        Task<IEnumerable<Product>> GetNewArrivalsAsync(int count);
		Task<IEnumerable<Product>> GetByCategoryAsync(Category category);

		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
	}
}
