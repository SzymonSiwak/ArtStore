namespace ArtStore.Shared.DTO
{
	public class UserProfileDto
	{
		public string Id { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string FullName => $"{FirstName} {LastName}";
		public List<ProductDto> Favorites { get; set; } = new();
	}
}
