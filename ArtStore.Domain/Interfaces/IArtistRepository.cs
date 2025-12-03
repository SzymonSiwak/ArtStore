using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Entities;

namespace ArtStore.Domain.Interfaces
{
    public interface IArtistRepository
    {
		Task<IEnumerable<Artist>> GetAllAsync();
		Task<Artist?> GetByIdAsync(Guid id);
		Task AddAsync(Artist artist);

	}
}
