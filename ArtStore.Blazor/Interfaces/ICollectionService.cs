using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface ICollectionService
    {
        Task<IEnumerable<CollectionDto>> GetAllCollectionsAsync();
    }
}
