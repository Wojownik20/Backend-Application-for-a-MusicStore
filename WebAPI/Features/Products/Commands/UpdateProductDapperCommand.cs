using MediatR;

namespace MusicStore.WebAPI.Features.Products.Commands
{
    public class UpdateProductDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public UpdateProductDapperCommand(int id, string name, string category, decimal price, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            ReleaseDate = releaseDate;
        }
    }
}
