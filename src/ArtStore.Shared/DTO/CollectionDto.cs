namespace ArtStore.Shared.DTO
{
    public class CollectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty; 
        public string BannerImageUrl { get; set; } = string.Empty;
    }
}
