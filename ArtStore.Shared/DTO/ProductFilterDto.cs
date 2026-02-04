using ArtStore.Shared.Enums;

namespace ArtStore.Shared.DTO
{
    public class ProductFilterDto
    {
        public string? CollectionName { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public FrameType? FrameType { get; set; }
        public Category? SpecificCategory { get; set; }
	}
}
