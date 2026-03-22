using ArtStore.Shared.Enums;

namespace ArtStore.Shared.DTO
{
    public class ProductFilterDto
    {
        public Guid? CategoryId { get; set; }
        public Guid? CollectionId { get; set; }

        public bool IsBestseller { get; set; }
        public bool IsNewArrival { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public FrameType? FrameType { get; set; }
	}
}
