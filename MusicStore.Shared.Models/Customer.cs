using System;
namespace MusicStore.Shared.Models;
public class Customer : BaseModel
{
		public string? Name { get; set; }
		public DateTime BirthDate { get; set; }
}
