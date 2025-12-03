using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using ArtStore.Domain.Common;

namespace ArtStore.Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty; //URL to the artist's avatar image

		//one-to-many relationship with Artworks
        public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
