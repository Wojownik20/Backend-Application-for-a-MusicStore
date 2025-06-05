namespace LeverX.WebAPI.Features.Customers.Dto;

public record CustomerReadDto 
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
}

