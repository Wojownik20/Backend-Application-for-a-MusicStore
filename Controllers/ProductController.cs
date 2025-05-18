using Microsoft.AspNetCore.Mvc;
using LeverX.Models;
using LeverX.ModelsD;

namespace LeverX.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class ProductController : ControllerBase //Base class
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "David Bowie - The Rise and Fall Of Ziggy Stardust And Spiders From Mars", Category = "Vinyl", Price = 149.99M, ReleaseDate = new DateTime(1972, 6, 6) },
        new Product { Id = 2, Name = "The Beatles - Get Back", Category = "CD", Price = 49.99M, ReleaseDate = new DateTime(1970, 5, 8) },
        new Product { Id = 3, Name = "Pink Floyd - Dark Side of the Moon", Category = "Vinyl", Price = 109.99M, ReleaseDate = new DateTime(1973, 3, 1) },
        new Product { Id = 4, Name = "Tyler The Creator - IGOR", Category = "CD", Price = 69.99M, ReleaseDate = new DateTime(2019, 5, 17) }
    };

    /// <summary>
    /// Returns a list of Products
    /// </summary>
    /// <returns>200 and JSON list of products</returns>
    [HttpGet] // GET /api/product
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_products); // return 200 OK + JSON List of Products
    }
   
    /// <summary>
    /// Returns a product of provided ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product or Error 404</returns>
    [HttpGet("{id}")] // GET api/product/{id}
    public ActionResult<Product> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id); 
        if (product == null) return NotFound(); //returns 404 not found
        return Ok(product);// returns 200 ok + product
    }

    /// <summary>
    /// Creates new product
    /// </summary>
    /// <param name="newProduct">New Product</param>
    /// <returns>201 + Link to get api/product</returns>
    [HttpPost]
    public ActionResult<Product> Create(ProductD productDtos)
    {
        var newProduct = new Product
        {
            Id = _products.Max(p => p.Id) + 1,
            Name = productDtos.Name,
            Category = productDtos.Category,
            Price = productDtos.Price,
            ReleaseDate = productDtos.ReleaseDate
        };

        _products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);

    }

    /// <summary>
    /// Updating a product according to its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <param name="updatedProduct">Updated product</param>
    /// <returns>204 if product updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductD productDtos)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if(product==null)
        {
            return NotFound();
        }
        else
        {
            product.Name = productDtos.Name;
            product.Category = productDtos.Category;
            product.Price = productDtos.Price;
            product.ReleaseDate = productDtos.ReleaseDate;

            return NoContent();
        }

    }

    /// <summary>
    /// Delete product by its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>204 if product deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound(); // Return 404 if not found

        _products.Remove(product);
        return NoContent(); // Return 204 NoContent
    }
}
