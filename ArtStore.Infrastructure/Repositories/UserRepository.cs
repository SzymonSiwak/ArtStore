using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
	{
        private readonly ArtStoreDbContext _context;

        public UserRepository(ArtStoreDbContext context) 
        {
            _context = context;
		}

		public async Task<User?> GetByIdWithFavoritesAsync(string userId)
		{
			return await _context.Users
				.Include(u => u.Favorites)
				.ThenInclude(p => p.Artist)
				.FirstOrDefaultAsync(u => u.Id == userId);
		}

		public async Task UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}
	}
}
