using ArtStore.Domain.Common;
using ArtStore.Shared.Enums;
using ArtStore.Domain.ValueObjects;

namespace ArtStore.Domain.Entities
{
    public class Product: BaseEntity
	{
        public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

        //Price as VO
        public Money Price { get; set; } = new Money(0, "USD");

        //Dimensions of artwork
        public string Dimensions { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
        public FrameType Frame { get; set; } = FrameType.None;

        //flag for best sellers items
        public bool IsBestseller { get; set; }

        //Relation with Category
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        //Relation with Collection
        public ICollection<Collection> Collections { get; set; } = new List<Collection>();

        //Relations with Artist
        public Guid ArtistId { get; set; }
		public Artist? Artist { get; set; }
	}
}
