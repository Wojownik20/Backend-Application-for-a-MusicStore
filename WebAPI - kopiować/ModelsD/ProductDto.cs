using System;
namespace LeverX.WebAPI.ModelsD;
public class ProductDto
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
}
