using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();

        //Methods for categories on main page
        Task<IEnumerable<Product>> GetBestSellersAsync(int count);
        Task<IEnumerable<Product>> GetNewArrivalsAsync(int count);
		Task<IEnumerable<Product>> GetByCategoryAsync(Enums.Category category);

		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
	}
}
