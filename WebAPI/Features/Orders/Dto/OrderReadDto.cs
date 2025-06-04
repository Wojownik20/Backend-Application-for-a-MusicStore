namespace LeverX.WebAPI.Features.Orders.Dto;
public record OrderReadDto (int Id, int ProductId, int CustomerId, int EmployeeId, decimal TotalPrice, DateTime PurchaseDate);
