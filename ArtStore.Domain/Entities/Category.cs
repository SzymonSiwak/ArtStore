using ArtStore.Domain.Common;

namespace ArtStore.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // User-friendly URL
        public string Slug { get; set; } = string.Empty;

        //Relation Category-Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
