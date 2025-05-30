using System;
namespace LeverX.WebAPI.ModelsDto;
public class CustomerDto // FOR REST
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}

public class CustomerReadDto // FOR GET
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
