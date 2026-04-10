using ArtStore.Domain.Common;

namespace ArtStore.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public string? UserId { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Guid productId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
		}
	}
}
