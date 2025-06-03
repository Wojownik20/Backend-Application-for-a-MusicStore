using MediatR;

namespace MusicStore.WebAPI.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }


        public CreateProductCommand(string name, string category, decimal price, DateTime releaseDate)
        {
            Name = name;
            Category = category;
            Price = price;
            ReleaseDate = releaseDate;
        }
    }
}