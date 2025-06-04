namespace LeverX.WebAPI.Features.Products.Dto;
public record ProductReadDto (int Id, string Name, string Category, decimal Price, DateTime ReleaseDate);
