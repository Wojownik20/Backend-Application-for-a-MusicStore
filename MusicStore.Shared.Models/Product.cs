using System;
namespace MusicStore.Shared.Models;
public class Product : BaseModel
{
		public string Name { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
		public DateTime ReleaseDate { get; set; }
}
