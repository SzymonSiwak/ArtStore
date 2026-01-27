using ArtStore.Shared.DTOs;

namespace ArtStore.Blazor.Interfaces
{
    public interface IArtistService
    {
		Task<IEnumerable<ArtistDto>> GetAllArtists();
		Task<ArtistDetailsDto?> GetArtistById(Guid id);
	}
}
