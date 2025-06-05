namespace LeverX.WebAPI.Features.Orders.Dto;
public record OrderReadDto
{
    public int Id { get; set; }
    public int ProductId { get; init; }
    public int CustomerId { get; init; }
    public int EmployeeId { get; init; }
    public decimal TotalPrice { get; init; }
    public DateTime PurchaseDate { get; init; }

}