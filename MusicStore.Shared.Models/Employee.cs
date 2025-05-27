using System;
namespace MusicStore.Shared.Models;
public class Employee : BaseModel
{
		public string? Name { get; set; }
		public DateTime BirthDate { get; set; }
		public decimal Salary { get; set; }
}
