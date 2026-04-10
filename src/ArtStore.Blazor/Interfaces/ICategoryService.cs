using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    }
}
