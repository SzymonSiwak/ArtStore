using ArtStore.Domain.Common;

namespace ArtStore.Domain.Entities
{
    public class Collection : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string BannerImageUrl { get; set; } = string.Empty; 

        // Relation Collection-Product 
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
