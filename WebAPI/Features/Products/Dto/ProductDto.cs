namespace LeverX.WebAPI.Features.Products.Dto;
public record ProductDto
{
    public string Name { get; init; }
    public string Category { get; init; } 
    public decimal Price { get; init; } 
    public DateTime ReleaseDate { get; init; } 
}



