using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Common;

namespace ArtStore.Domain.Entities
{
    public class CartItem : BaseEntity
    {
		public Guid ProductId { get; set; }
		public Product? Product { get; set; }

		public int Quantity { get; set; }

		public Guid CartId { get; set; }
	}
}
