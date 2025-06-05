using MediatR;

namespace MusicStore.WebAPI.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public CreateOrderCommand(int productId, int customerId, int employeeId, decimal totalPrice, DateTime purchaseDate)
        {
            ProductId = productId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
        }
    }
}