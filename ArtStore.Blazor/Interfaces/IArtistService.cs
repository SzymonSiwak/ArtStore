using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface IArtistService
    {
		Task<IEnumerable<ArtistDto>> GetAllArtists();
		Task<ArtistDetailsDto?> GetArtistById(Guid id);
	}
}
