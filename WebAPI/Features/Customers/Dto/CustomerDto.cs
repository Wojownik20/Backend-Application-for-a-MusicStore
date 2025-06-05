namespace LeverX.WebAPI.Features.Customers.Dto;
public record CustomerDto
{
    public string Name { get; init; } 
    public DateTime BirthDate { get; init; }
}

