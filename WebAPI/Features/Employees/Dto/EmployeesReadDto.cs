namespace LeverX.WebAPI.Features.Employees.Dto;
public record EmployeeReadDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime BirthDate { get; init; }
    public decimal Salary { get; init; }
}