using MediatR;

namespace MusicStore.WebAPI.Features.Orders.Commands
{
    public class UpdateOrderDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public UpdateOrderDapperCommand(int id, int productId, int customerId, int employeeId, decimal totalPrice, DateTime purchaseDate)
        {
            Id = id;
            ProductId = productId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
        }
    }
}