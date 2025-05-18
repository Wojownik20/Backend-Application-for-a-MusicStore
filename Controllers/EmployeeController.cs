using Microsoft.AspNetCore.Mvc;
using LeverX.Models;

namespace LeverX.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class EmployeeController : ControllerBase //Base class
{
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee {Id = 1 , Name = "Robert Lewandowski", BirthDate = new DateTime(1992,6,15),Salary = 5000m},
        new Employee {Id = 2 , Name = "Wojtek Szczęsny", BirthDate = new DateTime(1991,10,2), Salary = 6500m},
        new Employee {Id = 3 , Name = "Nicola Zalewski", BirthDate = new DateTime(1992,4,10), Salary = 3250m}
    };

    /// <summary>
    /// Gets all employees
    /// </summary>
    /// <returns>200 and JSON list of Employees</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAll()
    {
        return Ok(_employees); // return 200 OK 
    }

    /// <summary>
    /// Gets Employee by id
    /// </summary>
    /// <param name="id">Id of the employee</param>
    /// <returns>200 if Employee found by id, 404 if id not found</returns>
    [HttpGet("{id}")]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
            return NotFound();
        else
        {
            return Ok(employee); //200 Ok
        }
    }

    /// <summary>
    /// Creates an Employee
    /// </summary>
    /// <param name="newEmployee">New employee</param>
    /// <returns>201 when Employee created</returns>
    [HttpPost]
    public ActionResult<Employee> Create(EmployeeD employeeDtos)
    {
        var newEmployee = new Employee
        {
            Name = employeeDtos.Name,
            BirthDate = employeeDtos.BirthDate,
            Salary = employeeDtos.Salary
        };
        _employees.Add(newEmployee);
        return CreatedAtAction(nameof(GetById), new { id = newEmployee.Id }, newEmployee);
    }

    /// <summary>
    /// Updates an Employee record
    /// </summary>
    /// <param name="id">id of employee</param>
    /// <param name="updatedEmployee">Updated Employee</param>
    /// <returns>204 if updated succesfuly, 404 if id not found</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, EmployeeD employeeDtos)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        else
        {
            employee.Name = employeeDtos.Name;
            employee.BirthDate = employeeDtos.BirthDate;
            employee.Salary = employeeDtos.Salary;
            return NoContent();
        }
    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id">id of an employee</param>
    /// <returns>204 if deletion successful, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        else
        {
            _employees.Remove(employee);
            return NoContent();
        }
    }
}
