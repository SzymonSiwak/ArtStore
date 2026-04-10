using Microsoft.AspNetCore.Identity;

namespace ArtStore.Domain.Entities
{
    public class User : IdentityUser
    {
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public ICollection<Product> Favorites { get; set; } = new List<Product>();

		//TODO: add properties as address, order history, etc.
	}
}
