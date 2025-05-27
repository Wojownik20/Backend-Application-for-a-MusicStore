using System;
namespace MusicStore.Shared.Models;
public class Order : BaseModel
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
}
